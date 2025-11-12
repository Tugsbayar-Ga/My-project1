using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float move;
    public float speed = 5f;
    public float jumpForce = 10f;
    private bool isFacingRight = true;
    public Animator anim;

    // Dash
    public float dashForce = 15f;
    public float dashTime = 0.2f;
    private bool isDashing;
    private float dashTimeLeft;
    private float timeSinceDash = 1f;

    // Jump
    public Transform groundChecker;
    public LayerMask groundLayer;
    public int jumpNumMax = 2;
    private int jumpNum;
    private float timeSinceJump = 0f;
    public float timeBetweenJump = 0.25f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpNum = jumpNumMax;
    }

    void Update()
    {
        timeSinceJump += Time.deltaTime;
        timeSinceDash += Time.deltaTime;

        move = Input.GetAxisRaw("Horizontal");

        bool isGrounded = Physics2D.OverlapCircle(groundChecker.position, 0.3f, groundLayer);
        if (isGrounded)
        {
            jumpNum = jumpNumMax;
        }

        // Rörelse (om inte dashar)
        if (!isDashing)
            rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        // Hop
        if (Input.GetAxisRaw("Jump") > 0 && timeSinceJump >= timeBetweenJump && jumpNum > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            timeSinceJump = 0f;
            jumpNum--;
        }

        // Dash
        if (Input.GetButtonDown("Fire1") && !isDashing)
        {
            isDashing = true;
            dashTimeLeft = dashTime;
            float direction = isFacingRight ? 1f : -1f;
            rb.linearVelocity = new Vector2(direction * dashForce, rb.linearVelocity.y);
            timeSinceDash = 0f;
        }

        if (isDashing)
        {
            dashTimeLeft -= Time.deltaTime;
            if (dashTimeLeft <= 0)
                isDashing = false;
        }

        // Animation
        anim.SetBool("isRuning", Mathf.Abs(move) > 0.1f);
        anim.SetBool("isJumping", !isGrounded);
        
        if (!isFacingRight && move > 0f)
            Flip();
        else if (isFacingRight && move < 0f)
            Flip();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
