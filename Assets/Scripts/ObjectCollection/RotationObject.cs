using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{

        public float scaleFactor = 0.1f; // boyut �l�e�i fakt�r�
        public float minScale = 0.5f; // en k���k boyut
        public float maxScale = 2f; // en b�y�k boyut
        private bool isIncreasing = true; // boyut art�yor mu?

        void Update()
        {
            // boyutu art�r ya da k���lt
            if (isIncreasing)
            {
                transform.localScale += new Vector3(scaleFactor, scaleFactor, 0) * Time.deltaTime;
            }
            else
            {
                transform.localScale -= new Vector3(scaleFactor, scaleFactor, 0) * Time.deltaTime;
            }

            // objenin boyutu art�yor ve en b�y�k boyuta ula�t�ysan, boyutu k���lt
            if (isIncreasing && transform.localScale.x >= maxScale)
            {
                isIncreasing = false;
            }
            // objenin boyutu k���l�yor ve en k���k boyuta ula�t�ysan, boyutu art�r
            else if (!isIncreasing && transform.localScale.x <= minScale)
            {
                isIncreasing = true;
            }
        }
    



}







