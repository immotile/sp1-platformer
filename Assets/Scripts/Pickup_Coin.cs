using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            collision.GetComponent<PlayerState>().CoinPickup();
            Destroy(gameObject);
        }
    }
}
