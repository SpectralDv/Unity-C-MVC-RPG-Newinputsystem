using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Controller.Game;
namespace View
{
    public class ViewGame : MonoBehaviour
    {
        private ViewCanvas viewCanvas;

        private ViewCamera viewCamera1;
        private ViewCamera viewCamera2;
        private ViewCamera viewCamera3;
        private ViewCamera viewCamera4;


        private ControllerGame controllerGame;

        void Awake()
        {
            controllerGame = new ControllerGame();

            viewCanvas = GameObject.FindGameObjectWithTag("tagCanvas").gameObject.GetComponent<ViewCanvas>();

            //var viewCameras = FindObjectsOfType<ViewCamera>();
            //viewCamera1 = transform.Find("Player1").GetComponent<ViewCamera>();
            //viewCamera2 = transform.Find("Player2").GetComponent<ViewCamera>();
            //viewCamera3 = transform.Find("Player3").GetComponent<ViewCamera>();
            //viewCamera4 = transform.Find("Player4").GetComponent<ViewCamera>();
        }

        public void ButtonNonPlayer()
        {
            controllerGame.ChangeCountPlayer(0);
            viewCanvas.ChangeCountPlayer(0);
        }

        public void ButtonOnePlayer()
        {
            controllerGame.ChangeCountPlayer(1);
            viewCanvas.ChangeCountPlayer(1);
        }
        public void ButtonTwoPlayer()
        {
            controllerGame.ChangeCountPlayer(2);
            viewCanvas.ChangeCountPlayer(2);
        }
        public void ButtonThreePlayer()
        {
            controllerGame.ChangeCountPlayer(3);
            viewCanvas.ChangeCountPlayer(3);
        }
        public void ButtonFourPlayer()
        {
            controllerGame.ChangeCountPlayer(4);
            viewCanvas.ChangeCountPlayer(4);
        }

    }
}

