using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu_LevelSelector : MonoBehaviour, ISelectHandler
{
    [SerializeField] private int level;

    public void OnSelect(BaseEventData eventData)
    {
        print("selected level: "+level);
        PlayerPrefs.SetInt("SelectedLevel", level);
    }
  
}

