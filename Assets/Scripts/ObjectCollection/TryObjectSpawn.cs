using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TryObjectSpawn : MonoBehaviour
{


    public Transform[] spawnPoints; // spawn noktalar�
    public GameObject[] spawnObjects; // spawn edilecek objeler

    void Start()
    {
        int spawnPointCount = spawnPoints.Length; // spawn noktalar�n�n say�s�
        int spawnObjectIndex = 0; // spawn edilecek objeler dizisinde hangi obje kullan�lacak

        for (int i = 0; i < spawnPointCount; i++)
        {
            // i. spawn noktas�nda spawn edilecek objeyi belirle
            GameObject currentObject = spawnObjects[spawnObjectIndex];

            // spawn noktas�nda objeyi spawn et
            Instantiate(currentObject, spawnPoints[i].position, Quaternion.identity);

            // spawn edilecek objeler dizisindeki son objeyi spawn ettik, liste kar��t�r ve bir sonraki spawn noktas�nda ilk objeden ba�layaca��z
            if (spawnObjectIndex == spawnObjects.Length - 1)
            {
                spawnObjectIndex = 0;
                ShuffleArray(spawnObjects); // spawnObjects dizisini kar��t�r
            }
            else
            {
                spawnObjectIndex++;
            }
        }
    }

    // bir diziyi kar��t�rmak i�in kullan�lan y�ntem
    void ShuffleArray<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}


