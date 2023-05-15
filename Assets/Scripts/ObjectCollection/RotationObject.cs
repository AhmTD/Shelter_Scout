using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{

        public float scaleFactor = 0.1f; // boyut ölçeði faktörü
        public float minScale = 0.5f; // en küçük boyut
        public float maxScale = 2f; // en büyük boyut
        private bool isIncreasing = true; // boyut artýyor mu?

        void Update()
        {
            // boyutu artýr ya da küçült
            if (isIncreasing)
            {
                transform.localScale += new Vector3(scaleFactor, scaleFactor, 0) * Time.deltaTime;
            }
            else
            {
                transform.localScale -= new Vector3(scaleFactor, scaleFactor, 0) * Time.deltaTime;
            }

            // objenin boyutu artýyor ve en büyük boyuta ulaþtýysan, boyutu küçült
            if (isIncreasing && transform.localScale.x >= maxScale)
            {
                isIncreasing = false;
            }
            // objenin boyutu küçülüyor ve en küçük boyuta ulaþtýysan, boyutu artýr
            else if (!isIncreasing && transform.localScale.x <= minScale)
            {
                isIncreasing = true;
            }
        }
    



}







