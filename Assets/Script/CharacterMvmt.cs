using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMvmt : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionReference;
    [SerializeField] private InputActionReference boostActionReference;

    private Vector3 B;
    private Vector3 A;
    float lastBoost;

    float speed = 0.2f;
    float startTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastBoost = Time.time;
        startTime = Time.time;
        A = new Vector3(0, 0, 0);
        B = new Vector3(0, 0, 10);
        transform.position = A;
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
        if (boostActionReference.action.phase == InputActionPhase.Performed) { 
            transform.position = transform.position + directorVector.normalized;
        }
    }
}
