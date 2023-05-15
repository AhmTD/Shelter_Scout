using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject timeLoseUI;

    public GameObject finish;


    void Update()
    {
        GameOver();
        Invoke("Win", 4f);

     
    }
    private void GameOver()
    {
        if (PlayerController.isGameOver == true)
        {
            loseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }
         if (PlayerController.isTimeGameOver==true)
        {
            timeLoseUI.SetActive(true);
            Time.timeScale = 0.0f;
        }

    }
    private void Win()
    {
        if (PlayerController.isWin == true&& SceneManager.GetActiveScene().buildIndex != 4)
        {
            GameObject gb = GameObject.Find("UIScore");
            gb.SetActive(false);
            winUI.SetActive(true);
            Time.timeScale = 0.0f;


        }
        if (PlayerController.isWin == true && SceneManager.GetActiveScene().buildIndex == 4)
        {
            GameObject gb = GameObject.Find("UIScore");
            gb.SetActive(false);
            finish.SetActive(true);
            Time.timeScale = 0.0f;
        }
       
       
    }



}
