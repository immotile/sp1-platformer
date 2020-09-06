using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckPoint : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
       animator = gameObject.GetComponent<Animator>();
    }

   private void OnTriggerEnter2D(Collider2D collision) {
       if(collision.CompareTag("Player")){
           collision.GetComponent<PlayerState>().ChangeRespawnPosition(gameObject);
           animator.SetBool("IsCheckPointCaptured", true);
       }
   }
}
