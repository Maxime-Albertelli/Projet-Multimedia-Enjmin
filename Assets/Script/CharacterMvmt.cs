using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMvmt : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionReference;
    [SerializeField] private InputActionReference boostActionReference;
    [SerializeField] private float dashCooldown;
    private float lastDash;
    private float beginDashing;
    private bool isDashing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = Vector3.zero;
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x * 0.2f, 0, frameMovement.y * 0.2f);
        Vector3 newPosition = transform.position + frameMovement3D;
        Vector3 directorVector = newPosition - transform.position;
        transform.position = newPosition;
        if (directorVector.magnitude != 0)
        {
            Quaternion playerOrientation = Quaternion.LookRotation(directorVector, Vector3.up);
            transform.rotation = playerOrientation;
        }

        if (boostActionReference.action.phase == InputActionPhase.Performed && Time.time - lastDash > dashCooldown) {
            isDashing = true;
            lastDash = Time.time;
            beginDashing = Time.time;
        }

        if (isDashing && Time.time - beginDashing <= 0.15f) {
            gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            transform.position = transform.position + directorVector.normalized;
        }
        else if (isDashing && Time.time - beginDashing > 0.15f)
        {
            gameObject.GetComponent<Rigidbody>().detectCollisions = true;
            isDashing = false;
        }
    }
}
