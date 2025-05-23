using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Animator animator;
    public float moveSpeed = 10f;
    public float jumpForce = 15f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool wasGrounded = isGrounded;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);

        // Movimento lateral
        float moveX = Input.GetAxis("Horizontal");
        Vector3 newVelocity = rb.velocity;
        newVelocity.x = moveX * moveSpeed;
        rb.velocity = newVelocity;

        // Animação para correr
        Vector3 direction = new Vector3(moveX, 0, 0);
        if (moveX != 0)
        {
            animator.SetBool("correndo", true);
            transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("correndo", false);
        }

        // Pulo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }

        // pulou
        if (!isGrounded && wasGrounded)
        {
            animator?.SetBool("pulando", true);
        }

        // de volta no chão
        if (isGrounded && !wasGrounded)
        {
            animator?.SetBool("pulando", false);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
