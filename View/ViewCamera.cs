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

        private Vector3 gPRotation; //���� ������
        private Quaternion PRotation; //����������� ������
        private float limitDown = -10; 
        private float limitUp = 40; 

        private float roteVerValue;
        private float roteX;

        void Start()
        {
            //��������� ������� ������
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
            //������ ��������� ������
            vTarget = Person.transform.position;

            //�������������� ������� ������ � ��������
            gPRotation = Person.transform.rotation.eulerAngles;
            //����������� ������
            PRotation = Person.transform.localRotation;

            gPRotation.x = Camera.transform.eulerAngles.x + roteVerValue;

            roteX = gPRotation.x;
            if (gPRotation.x > 180) { roteX = -360 + gPRotation.x; }

            roteX = Mathf.Clamp(roteX, limitDown, limitUp);

            //������� �� ������������ �����
            Camera.transform.position = PRotation * offset + vTarget + new Vector3(0, roteX / 8, 0);

            //������ ����������� ���� ������
            Camera.transform.localEulerAngles = new Vector3(roteX, gPRotation.y, 0);
        }

    }
}