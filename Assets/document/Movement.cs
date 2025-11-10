using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float dashForce = 15f;
    [SerializeField] private float dashTime = 0.2f;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private int maxJumps = 2;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;
    private bool isDashing;
    private float dashTimeLeft;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GroundCheck();
        Move();
        Jump();
        Dash();
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded) jumpCount = 0; // återställ hopp när man landar
    }

    void Move()
    {
        if (isDashing) return;

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1f, 1f);
    }

    void Jump()
    {
        if (isDashing) return;

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount++;
        }
    }

    void Dash()
    {
        if (Input.GetButtonDown("Fire1") && !isDashing)
        {
            isDashing = true;
            dashTimeLeft = dashTime;

            float direction = transform.localScale.x;
            rb.linearVelocity = new Vector2(direction * dashForce, 0f);
        }

        if (isDashing)
        {
            dashTimeLeft -= Time.deltaTime;
            if (dashTimeLeft <= 0)
                isDashing = false;
        }
    }
}