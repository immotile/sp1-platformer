using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_DestroyOnMapBottom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy")){
            Destroy(collision.gameObject.transform.parent.gameObject);
        }
    }
}
