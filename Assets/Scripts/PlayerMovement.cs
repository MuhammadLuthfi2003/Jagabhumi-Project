using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    private bool doubleJump;

    private float dirX = 0;
    [SerializeField]private float moveSpeed = 7f;
    [SerializeField]private float jumpForce = 14f;
    [SerializeField]private LayerMask jumpableGround;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource stepSound;

    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if(rb.velocity.x != 0 && IsGrounded()){
            if(!stepSound.isPlaying){
                stepSound.Play();
            }
        }
        else{
            stepSound.Stop();
        }    

        if(IsGrounded() && !Input.GetButton("Jump")){
            doubleJump = false;
        }

        if(Input.GetButtonDown("Jump")){
            
            if(IsGrounded() || doubleJump){
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                doubleJump = !doubleJump;
                jumpSound.Play();
            }
        }

        if(Input.GetButtonUp("Jump") && rb.velocity.y > 0f){
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        UpdateAnimation();

    }

    private void UpdateAnimation(){

        MovementState state;
        
        if(dirX > 0f){
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(dirX < 0f){
            state = MovementState.running;
            sprite.flipX = true;
        }
        else{
            state = MovementState.idle;
        }

        if(rb.velocity.y > 0.1f){
            state = MovementState.jumping;
        }

        else if (rb.velocity.y < -0.1f){
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
