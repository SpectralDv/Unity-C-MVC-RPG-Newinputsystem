using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace View
{
    public class ViewFPS : MonoBehaviour
    {
        private float countFrame;
        private float sTimer = 0;

        private Text fps;

        void Awake()
        {
            fps = transform.Find("FPStext").GetComponent<Text>();


            Application.targetFrameRate = 60;
        }

        void Update()
        {
            sTimer += Time.deltaTime;

            if (sTimer < 1)
            {
                countFrame++;
            }
            if (sTimer >= 1)
            {
                fps.text = countFrame.ToString();
                sTimer = 0;
                countFrame = 0;
            }
        }

        public float GETFPS()
        {
            return countFrame;
        }

        public float GetDeltaTime()
        {
            return 60 / countFrame;
        }
    }
}