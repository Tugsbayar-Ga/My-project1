using UnityEngine;

public class PlayerMove : MonoBehaviour
{
private Rigidbody2D rb;
private float Move;
public float speed;
public float jump;
public bool isFacingRight;
    public Animator anim;
public float dashForce = 15f;
public float dashTime = 0.2f;
private bool isDashing;
private float dashTimeLeft;

// Start is called before the first frame update
void Start()
{
isFacingRight = true;
rb = GetComponent<Rigidbody2D>();
}

// Update is called once per frame
void Update()
{
Move = Input.GetAxisRaw("Horizontal");
rb.linearVelocity = new Vector2(Move * speed, rb.linearVelocity.y);

if (Input.GetButtonDown("Fire1") && !isDashing)
{
    isDashing = true;
    dashTimeLeft = dashTime;
    float direction = isFacingRight ? 1f : -1f;
    rb.linearVelocity = new Vector2(direction * dashForce, rb.linearVelocity.y);
}
if (isDashing)
{
    dashTimeLeft -= Time.deltaTime;
    if (dashTimeLeft <= 0)
    {
        isDashing = false;
    }
}

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
        }

if (Move >= 0.1f || Move <= -0.1f)
{
anim.SetBool("isRuning", true);
}
else
{
anim.SetBool("isRuning", false);
}

if (!isFacingRight && Move > 0f)
{
Flip();
}
else if (isFacingRight && Move < 0f)
{
Flip();
}
}

private void OnCollisionEnter2D(Collision2D other)
{
if (other.gameObject.CompareTag("Ground"))
{
anim.SetBool("isJumping", false);
}
}

private void OnCollisionExit2D(Collision2D other)
{
if (other.gameObject.CompareTag("Ground"))
{
anim.SetBool("isJumping", true);
}
}

private void Flip()
{
isFacingRight = !isFacingRight;
Vector3 localScale = transform.localScale;
localScale.x *= -1f;
transform.localScale = localScale;
}
}