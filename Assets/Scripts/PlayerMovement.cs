using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float fallMultiplier = 3f;
    public float lowJumpMultiplier = 2f;

    public float moveSpeed;

    [Range(5,15)]
    public float jumpVelocity;

    public bool isJumping = false;
    public bool isGrounded = false;
    public bool isClimbing = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;
    private float horizontalMovement;
    private float verticalMovement;

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer(horizontalMovement,verticalMovement);

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

    }

    void Update(){
        horizontalMovement = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        if(Input.GetButtonDown("Jump") && isGrounded){
            isJumping = true;
        }
        if(isGrounded){
            animator.SetBool("Jump",false);
        }
        else{animator.SetBool("Jump",true);}
        if (rb.velocity.y < 0){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rb.velocity.y > 0 && !Input.GetButtonDown("Jump")){
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement){
        if(!isClimbing){
            animator.SetBool("Climb",false);
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

            if ( isJumping ){
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse);
                isJumping=false;
            }
        }
        else{
            animator.SetBool("Climb",true);
            Vector3 targetVelocity = new Vector2(0, _verticalMovement);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
    }

    void Flip (float _velocity){
        if(_velocity>0.1f){
            spriteRenderer.flipX = false;
        }
        else if(_velocity<-0.1f){
            spriteRenderer.flipX = true;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
