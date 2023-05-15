using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TryObjectSpawn : MonoBehaviour
{


    public Transform[] spawnPoints; // spawn noktalarý
    public GameObject[] spawnObjects; // spawn edilecek objeler

    void Start()
    {
        int spawnPointCount = spawnPoints.Length; // spawn noktalarýnýn sayýsý
        int spawnObjectIndex = 0; // spawn edilecek objeler dizisinde hangi obje kullanýlacak

        for (int i = 0; i < spawnPointCount; i++)
        {
            // i. spawn noktasýnda spawn edilecek objeyi belirle
            GameObject currentObject = spawnObjects[spawnObjectIndex];

            // spawn noktasýnda objeyi spawn et
            Instantiate(currentObject, spawnPoints[i].position, Quaternion.identity);

            // spawn edilecek objeler dizisindeki son objeyi spawn ettik, liste karýþtýr ve bir sonraki spawn noktasýnda ilk objeden baþlayacaðýz
            if (spawnObjectIndex == spawnObjects.Length - 1)
            {
                spawnObjectIndex = 0;
                ShuffleArray(spawnObjects); // spawnObjects dizisini karýþtýr
            }
            else
            {
                spawnObjectIndex++;
            }
        }
    }

    // bir diziyi karýþtýrmak için kullanýlan yöntem
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


