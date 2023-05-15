using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speedAmount = 2f;
    Vector3 right = Vector3.right;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "RightWall")
        {
            transform.position -= right * speedAmount * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        }
        else if (collision.collider.tag == "LeftWall")
        {
            transform.position += right * speedAmount * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }
    }
    private void Move()
    {



        if ( transform.rotation.y == 0)
        {
            transform.position += right * speedAmount * Time.deltaTime;
        }
        else
        {
            transform.position -= right * speedAmount * Time.deltaTime;

        }


    }
}
