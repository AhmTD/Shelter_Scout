using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{

  


    public void RestartScene()
    {

        // �u anki sahnenin y�klenmesi i�in sahne ad�n� al�n
        string currentSceneName = SceneManager.GetActiveScene().name;
        // �u anki sahneyi yeniden y�kleyin
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1.0f;
        PlayerController.isGameOver = false;


    }
    public void LevelMap()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 4)
        {
          
          
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);

            Time.timeScale = 1.0f;
            PlayerController.isWin = false;
        }


    }

}
