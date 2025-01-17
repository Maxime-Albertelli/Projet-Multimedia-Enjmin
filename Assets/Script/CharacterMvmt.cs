using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMvmt : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionReference;
    [SerializeField] private InputActionReference boostActionReference;
    [SerializeField] private float dashCooldown;
    private CharacterController controller;
    private float lastDash;
    private float beginDashing;
    private bool isDashing = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion déplacement joueur
        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        Vector3 frameMovement3D = new Vector3(frameMovement.x * 0.2f, 0, frameMovement.y * 0.2f);
        Vector3 newPosition = transform.position + frameMovement3D;
        Vector3 directorVector = newPosition - transform.position;
        if (directorVector.magnitude != 0)
        {
            Quaternion playerOrientation = Quaternion.LookRotation(directorVector, Vector3.up);
            this.transform.rotation = playerOrientation;
        }
        controller.Move(frameMovement3D);

        //Gestion du dash
        if (boostActionReference.action.phase == InputActionPhase.Performed && Time.time - lastDash > dashCooldown) {
            isDashing = true;
            lastDash = Time.time;
            beginDashing = Time.time;
        }

        if (isDashing && Time.time - beginDashing <= 0.15f) {
            controller.detectCollisions = false;
            Vector3 dashVector = transform.position + directorVector.normalized*2;
            transform.position = dashVector;
        }
        else if (isDashing && Time.time - beginDashing > 0.15f)
        {
            controller.detectCollisions = true;
            isDashing = false;
        }
    }
}
