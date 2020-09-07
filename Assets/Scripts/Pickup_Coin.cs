using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour
{

    [SerializeField] private ParticleSystem particles;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickupClip;
    private bool canPickupCoin = true;
    private bool removeGameObject = false;
    private float timer;
    [SerializeField] private float timeBeforeDeletion;
    
    private void Update(){
        if(removeGameObject){
            timer += Time.deltaTime;
            if(timer >= timeBeforeDeletion){
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            if(canPickupCoin){
                collision.GetComponent<PlayerState>().CoinPickup();
                spriteRenderer.sprite = null;
                animator.enabled = false;
                particles.Play();
                canPickupCoin = false;
                removeGameObject = true;
                audioSource.pitch = Random.Range(0.9f, 1.1f);
                audioSource.PlayOneShot(pickupClip);
            }
        }
    }
}
