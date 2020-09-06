using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Quest_Giver : MonoBehaviour
{

    [SerializeField]private GameObject questGiverText;
    [SerializeField]private Text textComponent;
    [SerializeField]private int amountToCollect = 1;
    [SerializeField]private string questBeginnigText;    
    [SerializeField]private string questCompletionText;
    [SerializeField]private GameObject doorToOpenWhenQuestIsCompleted;

    // Start is called before the first frame update
    void Start()
    {
        questGiverText.SetActive(false);
        textComponent.text = questBeginnigText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            if(collision.GetComponent<PlayerState>().coinAmount >= amountToCollect){
                textComponent.text = questCompletionText;
                collision.GetComponent<Quest_Player>().isQuestCompleted = true;
                doorToOpenWhenQuestIsCompleted.SetActive(false);
            } else {
                textComponent.text = questBeginnigText;
            }

            questGiverText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
            questGiverText.SetActive(false);
        }
    }
}
