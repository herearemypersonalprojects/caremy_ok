using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    public float moveSpeed;
    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Joystick joystick;
    public float jumpSpeed = 5;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private bool SprintOn;

    void Update()
    {  

       horizontalMovement = joystick.Horizontal * moveSpeed;
       
       
       Flip(rb.velocity.x);

       float characterVelocity = Mathf.Abs(rb.velocity.x);
       animator.SetFloat("Speed", characterVelocity);
    }
   
    void FixedUpdate()
    {  
       isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);     
       MovePlayer(horizontalMovement);
       // Debug.Log(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.35f);
    }

    public void jumpButton()
    {
        SprintOn = true;
        if(SprintOn == true && isGrounded)
        {
        rb.velocity = Vector2.up * jumpSpeed;
        }else
        {
            SprintOn = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
             spriteRenderer.flipX = false;
        }else if(_velocity < -0.1f)
        {
             spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}