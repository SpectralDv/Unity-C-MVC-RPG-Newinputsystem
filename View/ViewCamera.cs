using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace View
{
    public class ViewCamera : MonoBehaviour
    {
        [SerializeField]
        private int cameraIndex = 0;
        public GameObject Camera;
        public GameObject Person;
        private Vector3 vTarget;

        private Vector3 offset;

        private Vector3 gPRotation; //углы игрока
        private Quaternion PRotation; //кватернионы игрока
        private float limitDown = -10; 
        private float limitUp = 40; 

        private float roteVerValue;
        private float roteX;

        void Start()
        {
            //начальная позиция камеры
            offset = Camera.transform.position;
            offset.x = 0;
            offset.y = 2;
            offset.z = -6;
        }

        void Update()
        {
            if (Person != null)
            {
                CameraMove();
            }
        }
        ////////////////////////////
        public int GetCameraIndex()
        {
            return cameraIndex;
        }
        public void SetPersonage(GameObject obj)
        {
            Person = obj;
        }
        ////////////////////////////
        public void SetRoteVer(float val)
        {
            roteVerValue = val;
        }

        private void CameraMove()
        {
            //вектор координат игрока
            vTarget = Person.transform.position;

            //горизонтальный поворот игрока в градусах
            gPRotation = Person.transform.rotation.eulerAngles;
            //кватарнионы игрока
            PRotation = Person.transform.localRotation;

            gPRotation.x = Camera.transform.eulerAngles.x + roteVerValue;

            roteX = gPRotation.x;
            if (gPRotation.x > 180) { roteX = -360 + gPRotation.x; }

            roteX = Mathf.Clamp(roteX, limitDown, limitUp);

            //следует за координатами игрок
            Camera.transform.position = PRotation * offset + vTarget + new Vector3(0, roteX / 8, 0);

            //камера присваивает углы игрока
            Camera.transform.localEulerAngles = new Vector3(roteX, gPRotation.y, 0);
        }

    }
}