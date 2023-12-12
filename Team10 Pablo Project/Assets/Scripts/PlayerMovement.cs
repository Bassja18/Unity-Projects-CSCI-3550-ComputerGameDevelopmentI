using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;       //Adjust to set jump high from ground. 

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime; //How much time the player can hang in the air before jumping
    private float coyoteCounter; //How much time passed since the player ran off the edge

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;    //Change this value to 1 in playermovement script to have 3 jumps rather than 2 (double)
    private int jumpCounter;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private float horizontalInput;

    private void Awake()
    {
        //Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Flip player when moving left-right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one * 0.6f;
        }   
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1) * 0.6f;
        }
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        //Adjustable jump height
        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
        {
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);
        } 
        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isGrounded())
            {
                coyoteCounter = coyoteTime; //Reset coyote counter when on the ground
                jumpCounter = extraJumps; //Reset jump counter to extra jump value
            }
            else
            {
                coyoteCounter -= Time.deltaTime; //Start decreasing coyote counter when not on the ground
            }   
        }

        AnimatePlayer();
    }

    private void Jump()
    {
        //If coyote counter is 0 or less and not on the wall and don't have any extra jumps don't do anything
        if (coyoteCounter <= 0 && jumpCounter <= 0) 
        {
            return; 
        }
        

        if (isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
        }
        else
        {
            //If not on the ground and coyote counter bigger than 0 do a normal jump
            if (coyoteCounter > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            }
            else
            {
                 if (jumpCounter > 0) //If we have extra jumps then jump and decrease the jump counter
                {
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                    jumpCounter--;
                    
                    //Replays jump animation
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    if (stateInfo.IsName("JumpStart"))
                    {
                        animator.Play(stateInfo.fullPathHash, 0, 0f);
                    }
                    else
                    {
                        animator.Play("JumpStart");
                    }
                }
            }
        }
        //Reset coyote counter to 0 to avoid double jumps
        coyoteCounter = 0;
    }

    //Checks to see if the player is on ground
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    //Updates animation on player based on parameters from movement
    private void AnimatePlayer()
    {
        if (animator != null)
        {
            animator.SetBool("In Air", !isGrounded());
            animator.SetBool("Walking", Mathf.Abs(horizontalInput) > 0.01f);
        }
    }
}