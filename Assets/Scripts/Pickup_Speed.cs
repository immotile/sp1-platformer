using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Speed : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float multiplySpeedBy = 1.5f;
    private PlayerMovement playerMovement;
    private bool isUsingMovementSpeed;
    private float timer = 0f;
    [SerializeField] private float timeBeforeReset;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isUsingMovementSpeed){
            timer += Time.deltaTime;
            if(timer >= timeBeforeReset){
                playerMovement.ResetMovementSpeed();
                timer = 0f;
                isUsingMovementSpeed = false;
                spriteRenderer.enabled = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(!isUsingMovementSpeed) {
            if(collision.CompareTag("Player")) {
                if(playerMovement == null){
                    playerMovement = collision.GetComponent<PlayerMovement>();
                }
                playerMovement.SetNewMovementSpeed(multiplySpeedBy);
                isUsingMovementSpeed = true;
                audioSource.PlayOneShot(audioClip);
                spriteRenderer.enabled = false;
            }
        }
    }
}
