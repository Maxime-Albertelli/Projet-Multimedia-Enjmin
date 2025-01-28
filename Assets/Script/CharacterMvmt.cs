using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMvmt : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionReference;
    [SerializeField] private InputActionReference boostActionReference;
    [SerializeField] private float dashCooldown;
    [SerializeField] private ParticleSystem dashParticle;
    private CharacterController controller;
    private CapsuleCollider damageZone;
    private float lastDash;
    private float beginDashing;
    private bool isDashing = false;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        damageZone = GetComponent<CapsuleCollider>();
        moveActionReference.action.Enable();
        boostActionReference.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Gestion déplacement joueur
        Vector2 frameMovement = moveActionReference.action.ReadValue<Vector2>();
        if(moveActionReference.action.IsPressed())
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
        Vector3 frameMovement3D = new Vector3(frameMovement.x * 20f, 0, frameMovement.y * 20f);
        Vector3 newPosition = transform.position + frameMovement3D;
        Vector3 directorVector = newPosition - transform.position;
        if (directorVector.magnitude != 0)
        {
            Quaternion playerOrientation = Quaternion.LookRotation(directorVector, Vector3.up);
            this.transform.rotation = Quaternion.Slerp(transform.rotation,playerOrientation,Time.deltaTime * 12f);
        }
        controller.Move(frameMovement3D * Time.deltaTime);


        //Gestion du dash
        if (boostActionReference.action.phase == InputActionPhase.Performed && Time.time - lastDash > dashCooldown) {
            animator.SetBool("isDashing", true);
            dashParticle.Play();
            Debug.Log("Dash");
            isDashing = true;
            lastDash = Time.time;
            beginDashing = Time.time;
        }

        if (isDashing && Time.time - beginDashing <= 0.15f) {
            dashParticle.Play();
            controller.detectCollisions = false;
            damageZone.enabled = false;
            Vector3 dashVector = transform.position + directorVector.normalized*2;
            transform.position = dashVector;
        }
        else if (isDashing && Time.time - beginDashing > 0.15f)
        {
            dashParticle.Stop();
            animator.SetBool("isDashing", false);
            controller.detectCollisions = true;
            damageZone.enabled = true;
            isDashing = false;
        }
    }
}
