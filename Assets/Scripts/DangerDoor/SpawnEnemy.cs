using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnDelay = 1.0f;
    public static int num;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Kapýya temas eden nesne karakter ise
            Invoke("SpawnEnemyControl", spawnDelay);
            gameObject.SetActive(false);
            int randomInt = Random.Range(0, 2);
            num = randomInt;
            Debug.Log(num);
        }
    }


    private void SpawnEnemyControl()
    {
        if (num == 1)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, 0);
            Vector3 spawnPosition = transform.position + transform.forward * 2.0f;
            Instantiate(enemyPrefab, spawnPosition, rotation );
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, 180, 0);
            Vector3 spawnPosition = transform.position + transform.forward * 2.0f;
            Instantiate(enemyPrefab, spawnPosition, rotation);
        }


    }
}
