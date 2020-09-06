using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FlyMovement : MonoBehaviour
{
    
    Rigidbody2D rigidBody2D;
    private Animator animator;
    public GameObject groundCheck;
    public float speed = 3f;
    private float movementDirection = 1f;
    private bool isGrounded;
    private bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
        groundCheck.name = "Jag är kantkontrollanten";
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool("isAlive", isAlive);
        animator.SetBool("isGrounded", isGrounded);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isAlive){
            if(isGrounded){
                Vector3 newPosition = gameObject.transform.position;
                newPosition.x += (speed * Time.fixedDeltaTime * movementDirection);
                rigidBody2D.MovePosition(newPosition);
            }
            
            CheckForGround();

            if(!isGrounded){
                ChangeDirection();
            }
        }
    }

    private void CheckForGround() {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
        isGrounded = false;

        for(int i = 0; i < colliders.Length; i++){
            if(colliders[i].gameObject != gameObject){
                isGrounded = true;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            ChangeDirection();
        }
    }

    private void ChangeDirection() {
        movementDirection = -movementDirection;
        Vector3 newScale = gameObject.transform.localScale;
        newScale.x = movementDirection;
        gameObject.transform.localScale = newScale;
    }

    public void KillMe(){
        if(isAlive){
            isAlive = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Vector2 killForce = new Vector2(movementDirection, 4f);
            rigidBody2D.AddForce(killForce, ForceMode2D.Impulse);
            // gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, -gameObject.transform.localScale.y);
        }
    }
}
