using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Timeline;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Object : MonoBehaviour
{


    public TextMeshProUGUI medKit, battery, gasCan, carTire, toolBag, bulletBox;
    public TextMeshProUGUI UImedkit, UIbattery, UIgasCan, UIcarTire, UItoolBag, UIbulletBox;
    private int collectedMedKit, collectedBattery, collectedGasCan, collectedCarTire, collectedToolBag, collectedBulletBox;
    public static bool level1, level2, level3, level4, level5 = false;
    private void Start()
    {
        UIcontrol();
        level1 = false;
        level2 = false;
        level3 = false;
        level4 = false;
        level5 = false;
    
      
    }
    private void Update()
    {
        LevelControl();
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (collision.gameObject.CompareTag("MedKit"))
            {

                collision.gameObject.SetActive(false);
                collectedMedKit++;
                UImedkit.text = collectedMedKit + "/1";
                if (collectedMedKit != 0)
                {

                    medKit.text = collectedMedKit + "/1";
                }


            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (collision.gameObject.CompareTag("Battery"))
            {

                collision.gameObject.SetActive(false);
                collectedBattery++;
                UIbattery.text = collectedBattery + "/2";
                if (collectedBattery != 0)
                {

                    battery.text = collectedBattery + "/2";
                }

            }

            if (collision.gameObject.CompareTag("GasCan"))
            {

                collision.gameObject.SetActive(false);
                collectedGasCan++;
                UIgasCan.text = collectedGasCan + "/2";
                if (collectedGasCan != 0)
                {

                    gasCan.text = collectedGasCan + "/2";
                }

            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (collision.gameObject.CompareTag("BulletBox"))
            {

                collision.gameObject.SetActive(false);
                collectedBulletBox++;
                UIbulletBox.text = collectedBulletBox + "/2";
                if (collectedBulletBox != 0)
                {

                    bulletBox.text = collectedBulletBox + "/2";
                }


            }

            if (collision.gameObject.CompareTag("Cartire"))
            {

                collision.gameObject.SetActive(false);
                collectedCarTire++;
                UIcarTire.text = collectedCarTire + "/3";
                if (collectedCarTire != 0)
                {

                    carTire.text = collectedCarTire + "/3";
                }


            }


        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (collision.gameObject.CompareTag("ToolBag"))
            {

                collision.gameObject.SetActive(false);
                collectedToolBag++;
                UItoolBag.text = collectedToolBag + "/3";
                if (collectedToolBag != 0)
                {

                    toolBag.text = collectedToolBag + "/3";
                }


            }

            if (collision.gameObject.CompareTag("GasCan"))
            {

                collision.gameObject.SetActive(false);
                collectedGasCan++;
                UIgasCan.text = collectedGasCan + "/2";
                if (collectedGasCan != 0)
                {

                    gasCan.text = collectedGasCan + "/2";
                }

            }


        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            if (collision.gameObject.CompareTag("MedKit"))
            {

                collision.gameObject.SetActive(false);
                collectedMedKit++;
                UImedkit.text = collectedMedKit + "/1";
                if (collectedMedKit != 0)
                {

                    medKit.text = collectedMedKit + "/1";
                }


            }

            if (collision.gameObject.CompareTag("Battery"))
            {

                collision.gameObject.SetActive(false);
                collectedBattery++;
                UIbattery.text = collectedBattery + "/2";
                if (collectedBattery != 0)
                {

                    battery.text = collectedBattery + "/2";
                }

            }

            if (collision.gameObject.CompareTag("BulletBox"))
            {

                collision.gameObject.SetActive(false);
                collectedBulletBox++;
                UIbulletBox.text = collectedBulletBox + "/2";
                if (collectedBulletBox != 0)
                {

                    bulletBox.text = collectedBulletBox + "/2";
                }


            }
        }
    }

    private void LevelControl()
    {
        if (collectedMedKit >= 1)
        {
            GameObject[] objectsToRemove = GameObject.FindGameObjectsWithTag("MedKit");

            // Tüm objeleri döngüye alarak kaldýr
            foreach (GameObject obj in objectsToRemove)
            {
                Destroy(obj);
            }
            level1 = true;

        }
        if (collectedBattery >= 2 || collectedGasCan >= 2)
        {
            GameObject[] objectsToRemove2 = GameObject.FindGameObjectsWithTag("Battery");
            GameObject[] objectsToRemove1 = GameObject.FindGameObjectsWithTag("GasCan");
            if (collectedBattery >= 2)
            {
                foreach (GameObject obj in objectsToRemove2)
                {
                    Destroy(obj);
                }
            }

            if (collectedGasCan >= 2)
            {
                foreach (GameObject obj in objectsToRemove1)
                {
                    Destroy(obj);
                }
            }
            if (collectedBattery >= 2 && collectedGasCan >= 2)
            {
                level2 = true;
            }

        }
        if (collectedCarTire >= 3 || collectedBulletBox >= 2)
        {
            GameObject[] objectsToRemove2 = GameObject.FindGameObjectsWithTag("Cartire");
            GameObject[] objectsToRemove1 = GameObject.FindGameObjectsWithTag("BulletBox");

            if (collectedCarTire >= 3)
            {
                foreach (GameObject obj in objectsToRemove2)
                {
                    Destroy(obj);
                }
            }
            if (collectedBulletBox >= 2)
            {
                foreach (GameObject obj in objectsToRemove1)
                {
                    Destroy(obj);
                }
            }
            if (collectedCarTire >= 3 && collectedBulletBox >= 2)
            {
                level3 = true;
            }
        }
        if (collectedToolBag >= 3 || collectedGasCan >= 2)
        {
            GameObject[] objectsToRemove2 = GameObject.FindGameObjectsWithTag("ToolBag");
            GameObject[] objectsToRemove1 = GameObject.FindGameObjectsWithTag("GasCan");


            if (collectedToolBag >= 3)
            {
                foreach (GameObject obj in objectsToRemove2)
                {
                    Destroy(obj);
                }
            }
            if (collectedGasCan >= 2)
            {
                foreach (GameObject obj in objectsToRemove1)
                {
                    Destroy(obj);
                }
            }

            if (collectedToolBag >= 3 && collectedGasCan >= 2)
            {
                level4 = true;
            }


        }
        if (collectedMedKit >= 1 || collectedBulletBox >= 2 || collectedBattery >= 2)
        {
            GameObject[] objectsToRemove2 = GameObject.FindGameObjectsWithTag("Battery");
            GameObject[] objectsToRemove1 = GameObject.FindGameObjectsWithTag("BulletBox");
            GameObject[] objectsToRemove3 = GameObject.FindGameObjectsWithTag("MedKit");
            if (collectedMedKit >= 1)
            {
                foreach (GameObject obj in objectsToRemove3)
                {
                    Destroy(obj);
                }

            }

            if (collectedBulletBox >= 2)
            {
                foreach (GameObject obj in objectsToRemove1)
                {
                    Destroy(obj);
                }

            }

            if (collectedBattery >= 2)
            {
                foreach (GameObject obj in objectsToRemove2)
                {
                    Destroy(obj);
                }

            }

            if (collectedMedKit >= 1 && collectedBulletBox >= 2 && collectedBattery >= 2)
            {
                level5 = true;
            }




        }

    }

    private void UIcontrol()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            UImedkit.text = "0/1";
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            UIbattery.text = "0/2";
            UIgasCan.text = "0/2";
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            UIbulletBox.text = "0/2";
            UIcarTire.text = "0/3";
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            UItoolBag.text = "0/3";
            UIgasCan.text = "0/2";
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            UImedkit.text = "0/1";
            UIbattery.text = "0/2";
            UIbulletBox.text = "0/2";

        }

    }

}


