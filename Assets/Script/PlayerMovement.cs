using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  
    public float moveSpeed;
    private bool isGrounded;
    public float jumpForce;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;
    public Joystick joystick;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private bool SprintOn;
    public bool PlateCk;

    public static PlayerMovement instance;

   private void Awake()
   {
       if(instance != null)
       {
        Debug.LogWarning("Il y a plus d'une instance de PlayerMovement dans la scène");
        return;

       }
       
    
       instance = this;
   }

    void Update()
    {           
       Flip(rb.velocity.x);

       float characterVelocity = Mathf.Abs(rb.velocity.x);
       animator.SetFloat("Speed", characterVelocity);
       
       if(PlateCk == true)
       {
           horizontalMovement = joystick.Horizontal * moveSpeed;
          moveSpeed = 5;

          if(Input.GetButtonDown("Jump") && isGrounded)
       {
         SprintOn = true;
        if(SprintOn == true && isGrounded)
        {
        rb.AddForce(new Vector2(0f, jumpForce));
        }else
        {
            SprintOn = false;
        }
       }
       }else 
       {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        MovePlayer(horizontalMovement);

        moveSpeed = 500;

        if(Input.GetButtonDown("Jump") && isGrounded)
       {
         SprintOn = true;
        if(SprintOn == true && isGrounded)
        {
        rb.AddForce(new Vector2(0f, jumpForce));
        }else
        {
            SprintOn = false;
        }
       }
       }
       
    }
   
    void FixedUpdate()
    {  
       isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);     
       MovePlayer(horizontalMovement);
       // Debug.Log(horizontalMovement);

       #if UNITY_ANDROID
           PlateCk = true;
           #endif

       #if UNITY_IOS
           PlateCk = true
           #endif

       #if UNITY_UNITY_STANDALONE_OSX
           PlateCk = false
           #endif

       #if UNITY_UNITY_STANDALONE_WIN
           PlateCk = false
           #endif
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
        rb.AddForce(new Vector2(0f, jumpForce));
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


