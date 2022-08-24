using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Controller.Canvas;
namespace View
{
    public class ViewCanvas : MonoBehaviour
    {
        private float ScreenWidth = 1920;
        private float ScreenHeight = 1080;

        public GameObject CameraCanvas;
        public Camera CameraPlayer1; //[x,y][w,h]=[0,0.5][0.5,0.5]
        public Camera CameraPlayer2; //[x,y][w,h]=[0.5,0.5][0.5,0.5]
        public Camera CameraPlayer3; //[x,y][w,h]=[0,0][0.5,0.5]
        public Camera CameraPlayer4; //[x,y][w,h]=[0.5,0][0.5,0.5]

        private RectTransform rectTransfrom1;
        private RectTransform rectTransfrom2;
        private RectTransform rectTransfrom3;
        private RectTransform rectTransfrom4;

        private RectTransform rectVisiblePanel1;
        private RectTransform rectVisiblePanel2;
        private RectTransform rectVisiblePanel3;
        private RectTransform rectVisiblePanel4;

        private GameObject ButtonMenuPlayer1;
        private GameObject ButtonMenuPlayer2;
        private GameObject ButtonMenuPlayer3;
        private GameObject ButtonMenuPlayer4;

        private GameObject SelectMenu1;
        private GameObject SelectMenu2;
        private GameObject SelectMenu3;
        private GameObject SelectMenu4;

        private GameObject VisiblePanel1;
        private GameObject VisiblePanel2;
        private GameObject VisiblePanel3;
        private GameObject VisiblePanel4;


        ControllerCanvas controllerCanvas;


        void Awake()
        {
            controllerCanvas = new ControllerCanvas();

            ButtonMenuPlayer1 = transform.Find("VisibleButton/ButtonMenuPlayer1").gameObject;
            ButtonMenuPlayer2 = transform.Find("VisibleButton/ButtonMenuPlayer2").gameObject;
            ButtonMenuPlayer3 = transform.Find("VisibleButton/ButtonMenuPlayer3").gameObject;
            ButtonMenuPlayer4 = transform.Find("VisibleButton/ButtonMenuPlayer4").gameObject;

            SelectMenu1 = transform.Find("SelectMenu/SelectMenu1").gameObject;
            SelectMenu2 = transform.Find("SelectMenu/SelectMenu2").gameObject;
            SelectMenu3 = transform.Find("SelectMenu/SelectMenu3").gameObject;
            SelectMenu4 = transform.Find("SelectMenu/SelectMenu4").gameObject;

            VisiblePanel1 = transform.Find("VisiblePanel/VisiblePlayer1").gameObject;
            VisiblePanel2 = transform.Find("VisiblePanel/VisiblePlayer2").gameObject;
            VisiblePanel3 = transform.Find("VisiblePanel/VisiblePlayer3").gameObject;
            VisiblePanel4 = transform.Find("VisiblePanel/VisiblePlayer4").gameObject;

            rectTransfrom1 = SelectMenu1.GetComponent<RectTransform>();
            rectTransfrom2 = SelectMenu2.GetComponent<RectTransform>();
            rectTransfrom3 = SelectMenu3.GetComponent<RectTransform>();
            rectTransfrom4 = SelectMenu4.GetComponent<RectTransform>();

            rectVisiblePanel1 = VisiblePanel1.GetComponent<RectTransform>();
            rectVisiblePanel2 = VisiblePanel2.GetComponent<RectTransform>();
            rectVisiblePanel3 = VisiblePanel3.GetComponent<RectTransform>();
            rectVisiblePanel4 = VisiblePanel4.GetComponent<RectTransform>();

        }

        void Start()
        {
            SpawnMenuPanel();
        }

        public void ChangeCountPlayer(int value)
        {
            controllerCanvas.SetCountPlayer(value);
            SpawnMenuPanel();
        }


        private void AddMenuPlayer(int numPlayer)
        {
            controllerCanvas.AddListMenuPanel("SelectPlayer" + numPlayer, new Vector3(0, 0, 0), new Vector2(0, 0));
            controllerCanvas.AddListMenuPanel("VisiblePanel" + numPlayer, new Vector3(0, 0, 0), new Vector2(0, 0));
        }

        private void RemoveMenuPlayer(int numPlayer)
        {
            controllerCanvas.RemoveListMenuPanel("SelectPlayer" + numPlayer);
            controllerCanvas.RemoveListMenuPanel("VisiblePanel" + numPlayer);
        }


        private void SpawnMenuPanel()
        {
            if (controllerCanvas.GetCountPlayer() == 0)
            {
                CameraCanvas.gameObject.SetActive(true);
                ChangeActiveMenuPanel(false, false, false, false);
            }
            if (controllerCanvas.GetCountPlayer() == 1)
            {
                CameraCanvas.gameObject.SetActive(false);
                ChangeActiveMenuPanel(true, false, false, false);

                CameraPlayer1.rect = new Rect(0.0f, 0.0f, 1.0f, 1.0f);

                rectTransfrom1.sizeDelta = new Vector2(0, -150);
                rectTransfrom1.anchoredPosition = new Vector3(0, 0, 0);

                rectVisiblePanel1.sizeDelta = new Vector2(1920, 1080);
                rectVisiblePanel1.anchoredPosition = new Vector3(0, 0, 0);
            }
            if (controllerCanvas.GetCountPlayer() == 2)
            {
                CameraCanvas.gameObject.SetActive(false);
                ChangeActiveMenuPanel(true, true, false, false);

                CameraPlayer1.rect = new Rect(0f, 0.0f, 0.5f, 1.0f);
                CameraPlayer2.rect = new Rect(0.5f, 0.0f, 0.5f, 1.0f);

                rectTransfrom1.sizeDelta = new Vector2(-ScreenWidth / 2, -150);
                rectTransfrom1.anchoredPosition = new Vector3(-ScreenWidth / 4, 0, 0);
                rectTransfrom2.sizeDelta = new Vector2(-ScreenWidth / 2, -150);
                rectTransfrom2.anchoredPosition = new Vector3(ScreenWidth / 4, 0, 0);

                rectVisiblePanel1.sizeDelta = new Vector2(1920 / 2,1080 );
                rectVisiblePanel1.anchoredPosition = new Vector3(-1920 / 4, 0, 0);
                rectVisiblePanel2.sizeDelta = new Vector2(1920 / 2, 1080 );
                rectVisiblePanel2.anchoredPosition = new Vector3(1920 / 4, 0, 0);
            }
            if (controllerCanvas.GetCountPlayer() == 3)
            {
                CameraCanvas.gameObject.SetActive(false);
                ChangeActiveMenuPanel(true, true, true, false);

                CameraPlayer1.rect = new Rect(0f, 0f, 0.333f, 1.0f);
                CameraPlayer2.rect = new Rect(0.333f, 0f, 0.333f, 1.0f);
                CameraPlayer3.rect = new Rect(0.666f, 0f, 0.333f, 1.0f);

                rectTransfrom1.sizeDelta = new Vector2(-ScreenWidth / 1.5f, -150);
                rectTransfrom1.anchoredPosition = new Vector3(-ScreenWidth / 3, 0, 0);
                rectTransfrom2.sizeDelta = new Vector2(-ScreenWidth / 1.5f, -150);
                rectTransfrom2.anchoredPosition = new Vector3(0, 0, 0);
                rectTransfrom3.sizeDelta = new Vector2(-ScreenWidth / 1.5f, -150);
                rectTransfrom3.anchoredPosition = new Vector3(ScreenWidth / 3, 0, 0);

                rectVisiblePanel1.sizeDelta = new Vector2(1920 / 3, 1080);
                rectVisiblePanel1.anchoredPosition = new Vector3(-1920 / 3, 0, 0);
                rectVisiblePanel2.sizeDelta = new Vector2(1920 / 3, 1080);
                rectVisiblePanel2.anchoredPosition = new Vector3(0, 0, 0);
                rectVisiblePanel3.sizeDelta = new Vector2(1920 / 3, 1080);
                rectVisiblePanel3.anchoredPosition = new Vector3(1920 / 3, 0, 0);
            }
            if (controllerCanvas.GetCountPlayer() == 4)
            {
                CameraCanvas.gameObject.SetActive(false);
                ChangeActiveMenuPanel(true, true, true, true);

                CameraPlayer1.rect = new Rect(0f, 0.5f, 0.5f, 0.5f);
                CameraPlayer2.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                CameraPlayer3.rect = new Rect(0f, 0f, 0.5f, 0.5f);
                CameraPlayer4.rect = new Rect(0.5f, 0, 0.5f, 0.5f);

                rectTransfrom1.sizeDelta = new Vector2(-ScreenWidth / 2, -60 - ScreenHeight / 2);
                rectTransfrom1.anchoredPosition = new Vector3(-ScreenWidth / 4, -30 + ScreenHeight / 4, 0);
                rectTransfrom2.sizeDelta = new Vector2(-ScreenWidth / 2, -60 - ScreenHeight / 2);
                rectTransfrom2.anchoredPosition = new Vector3(ScreenWidth / 4, -30 + ScreenHeight / 4, 0);
                rectTransfrom3.sizeDelta = new Vector2(-ScreenWidth / 2, -60 - ScreenHeight / 2);
                rectTransfrom3.anchoredPosition = new Vector3(-ScreenWidth / 4, -30 - ScreenHeight / 4, 0);
                rectTransfrom4.sizeDelta = new Vector2(-ScreenWidth / 2, -60 - ScreenHeight / 2);
                rectTransfrom4.anchoredPosition = new Vector3(ScreenWidth / 4, -30 - ScreenHeight / 4, 0);

                rectVisiblePanel1.sizeDelta = new Vector2(1920 / 2, 1080 / 2);
                rectVisiblePanel1.anchoredPosition = new Vector3(-1920 / 4, 1080 / 4, 0);
                rectVisiblePanel2.sizeDelta = new Vector2(1920 / 2, 1080 / 2);
                rectVisiblePanel2.anchoredPosition = new Vector3(1920 / 4, 1080 / 4, 0);
                rectVisiblePanel3.sizeDelta = new Vector2(1920 / 2, 1080 / 2);
                rectVisiblePanel3.anchoredPosition = new Vector3(-1920 / 4, -1080 / 4, 0);
                rectVisiblePanel4.sizeDelta = new Vector2(1920 / 2, 1080 / 2);
                rectVisiblePanel4.anchoredPosition = new Vector3(1920 / 4, -1080 / 4, 0);
            }
        }

        public void ChangeActiveMenuPanel(bool event1, bool event2, bool event3, bool event4)
        {
            ButtonMenuPlayer1.SetActive(event1);
            ButtonMenuPlayer2.SetActive(event2);
            ButtonMenuPlayer3.SetActive(event3);
            ButtonMenuPlayer4.SetActive(event4);

            VisiblePanel1.gameObject.SetActive(event1);
            VisiblePanel2.gameObject.SetActive(event2);
            VisiblePanel3.gameObject.SetActive(event3);
            VisiblePanel4.gameObject.SetActive(event4);

            CameraPlayer1.gameObject.SetActive(event1);
            CameraPlayer2.gameObject.SetActive(event2);
            CameraPlayer3.gameObject.SetActive(event3);
            CameraPlayer4.gameObject.SetActive(event4);
        }

    }
}

