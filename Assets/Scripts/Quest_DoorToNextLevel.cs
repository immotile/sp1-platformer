using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Quest_DoorToNextLevel : MonoBehaviour
{

    [SerializeField] private int levelToLoad;
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            if(collision.GetComponent<Quest_Player>().isQuestCompleted){
                GameObserver.SaveCoinsToMemory(collision.GetComponent<PlayerState>().coinAmount);
                SceneManager.LoadScene(levelToLoad);

            }
        }
    }
}
