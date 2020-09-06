using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_FlyHarmful : MonoBehaviour
{

    public int damage = 1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<PlayerState>().DoHarm(damage);
        }  
    }
}
