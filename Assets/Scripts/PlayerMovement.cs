using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 8f;
    private Rigidbody rb;
    private bool isGrounded = false;
    public Transform cameraTransform; // Assign Main Camera / FreeLook Camera here

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Fixed friction, no clinging to walls
        Collider col = GetComponent<Collider>();
        PhysicsMaterial noFriction = new PhysicsMaterial();
        noFriction.dynamicFriction = 0f;
        noFriction.staticFriction = 0f;
        noFriction.frictionCombine = PhysicsMaterialCombine.Minimum;
        col.material = noFriction;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false; // Will reset on collision with ground
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Camera forward/right on XZ plane
        Vector3 camForward = cameraTransform.forward;
        camForward.y = 0;
        camForward.Normalize();

        Vector3 camRight = cameraTransform.right;
        camRight.y = 0;
        camRight.Normalize();

        // Combine input relative to camera
        Vector3 movement = camForward * vertical + camRight * horizontal;

        // Apply velocity while keeping Y for gravity/jump
        rb.linearVelocity = new Vector3(movement.x * speed, rb.linearVelocity.y, movement.z * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // "Ground" Condition
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}