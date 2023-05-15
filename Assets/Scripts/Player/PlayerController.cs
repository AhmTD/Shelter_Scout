using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    

    public TextMeshProUGUI gameOverTMP;
    public Rigidbody2D rb2D;
    public float speedAmount = 2f;

    Vector3 right = Vector3.right;
    public float jumpForce = 50f;

    public bool jumpReady;
    public bool isJump = false;



    public float jumpCD = 1.2f;
    public float jumpCDCurrent = 0.0f;

    public float cameraHeight = 1f;
    public float cameraMoveSpeed = 1f;

    private Vector3 targetPosition;
    private bool isMoving = false;
    public static bool isGameOver;
    public static bool isTimeGameOver;
    public static bool isWin;

    public Camera camera2D;

    public TextMeshProUGUI countdownText;

    public float countdownValue;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            isGameOver = false;
            isTimeGameOver = false;
            countdownValue = 15f;
            Time.timeScale = 1.0f;

        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            isGameOver = false;
            isTimeGameOver = false;
            countdownValue = 20f;
            Time.timeScale = 1.0f;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            isGameOver = false;
            isTimeGameOver = false;
            countdownValue = 25f;
            Time.timeScale = 1.0f;
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            isGameOver = false;
            isTimeGameOver = false;
            countdownValue = 27f;
            Time.timeScale = 1.0f;
        }
         if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            isGameOver = false;
            isTimeGameOver = false;
            countdownValue = 35f;
            Time.timeScale = 1.0f;
        }




    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        Move();
        Jump();
        
       
    }
    private void Move()
    {
        if (transform.rotation.y == 0)
        {
            transform.position += right * speedAmount * Time.deltaTime;
        }
        else
        {
            transform.position -= right * speedAmount * Time.deltaTime;
        }

    }
    private void Jump()
    {

        if (jumpCDCurrent >= jumpCD)
        {
            jumpReady = true;
        }
        else
        {
            jumpCDCurrent += Time.deltaTime;
            jumpReady = false;
            jumpCDCurrent = Mathf.Clamp(jumpCDCurrent, 0.0f, jumpCD);

        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && isJump && jumpReady)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCDCurrent = 0.0f;
            targetPosition = camera2D.transform.position + new Vector3(0f, cameraHeight, 0f);
            isMoving = true;
            isJump = false;
        }

        if (isMoving)
        {
            float step = cameraMoveSpeed * Time.deltaTime;
            camera2D.transform.position = Vector3.Lerp(camera2D.transform.position, targetPosition, step);


            if (camera2D.transform.position == targetPosition)
            {
                isMoving = false;
            }
        }
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
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = true;
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isGameOver = true;
            Time.timeScale = 0.0f;
        }
        
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
          
            if (collision.collider.tag == "Win" && Object.level1 ==true )
            {
                isWin = true;
            }
             if (collision.collider.tag == "Win" && Object.level1 ==false )
            {
                isGameOver=true;
            }



        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
           
            if (collision.collider.tag =="Win" && Object.level2 == true)
            {
                isWin = true;
            }
            if (collision.collider.tag =="Win" && Object.level2 ==false)
            {
                isGameOver=true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
           

            if (collision.collider.tag =="Win" && Object.level3 ==true)
            {
                isWin = true;
            }
            if (collision.collider.tag =="Win"&& Object.level3 ==false)
            {
                isGameOver = true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
           

            if (collision.collider.tag =="Win" && Object.level4 ==true)
            {
                isWin = true;
            }
            if (collision.collider.tag =="Win"&& Object.level4 ==false)
            {
                isGameOver = true;
            }
        }
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
           

            if (collision.collider.tag =="Win" && Object.level5 ==true)
            {
                isWin = true;

            }
            if (collision.collider.tag =="Win"&& Object.level5 ==false)
            {
                isGameOver = true;
            }
        }



    }

    private void Timer()
    {


        if (countdownValue > 0f)
        {
            countdownValue -= 1f * Time.deltaTime;
            countdownText.text = Mathf.RoundToInt(countdownValue).ToString();

        }
        else
        {
            Debug.Log(isGameOver);
            isTimeGameOver = true;

        }
    }



}
