using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    public GameObject groundCheck;
    public float movementSpeed = 5f;
    private float defaultMovementSpeed;
    private float moveDirection = 0f;
    public float jumpForce = 6f;
    private bool isJumpPressed;
    public bool isGrounded;
    private bool isFacingLeft;
    private Vector3 velocity;
    public float smoothTime;

   [SerializeField] private LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        defaultMovementSpeed = movementSpeed;
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        isFacingLeft = true;
        smoothTime = 0.05f;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Input.GetAxis("Horizontal");


        if(Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
            animator.SetTrigger("DoJump");
        }

        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("speed", Mathf.Abs(moveDirection));

    }

    private void FixedUpdate() {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f, whatIsGround);
        isGrounded = false;

        for(int i = 0; i < colliders.Length; i++){
            if(colliders[i].gameObject != gameObject){
                isGrounded = true;
            }
        }

        Vector3 calculatedMovement = Vector3.zero;
        float verticalVelocity = 0f;

        if(!isGrounded){
            verticalVelocity = rigidBody2D.velocity.y;
        }

        calculatedMovement.x = movementSpeed * 100f * moveDirection * Time.fixedDeltaTime;
        calculatedMovement.y = verticalVelocity;
        Move(calculatedMovement, isJumpPressed);
        isJumpPressed = false;

    }

    private void Move(Vector3 moveDirection, bool isJumpPressed){

        rigidBody2D.velocity = Vector3.SmoothDamp(rigidBody2D.velocity, moveDirection, ref velocity, smoothTime);

        if(isJumpPressed && isGrounded){
            rigidBody2D.AddForce(new Vector2(0f, jumpForce * 100f));
        }

        if(moveDirection.x > 0f && isFacingLeft){
            FlipSpriteDirection();
        } else if(moveDirection.x < 0f && !isFacingLeft){
            FlipSpriteDirection();
        }
    }

    private void FlipSpriteDirection(){
        spriteRenderer.flipX = !isFacingLeft;
        isFacingLeft = !isFacingLeft;
    }

    public bool isFalling(){
        if(rigidBody2D.velocity.y < -1f){
            return true;
        } else {
            return false;
        }
    }

    public void ResetMovementSpeed(){
        movementSpeed = defaultMovementSpeed;
    }

    public void SetNewMovementSpeed(float multiplyBy){
        movementSpeed *= multiplyBy;
    }
}
