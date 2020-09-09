using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu_StartGame : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.SetInt("SelectedLevel", 1);
    }

    public void StartGame(){
        PlayerPrefs.SetInt("CoinAmount", 0);
        //If no specific level has been selected, level 1 should be used
        SceneManager.LoadScene(PlayerPrefs.GetInt("SelectedLevel") == 0 ? 1 : PlayerPrefs.GetInt("SelectedLevel"));
    }
}
