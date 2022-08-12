using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using SpaceAnimator;
using Slot;
using Player;
using Weapon;
using Personage;
namespace View
{
    public class ViewPersonage : MonoBehaviour
    {
        public ControllerPersonage controllerPersonage;
        private ControllerAnimator controllerAnimator;

        private ViewCamera viewCamera;
        private ViewAnimator viewAnimator;
        private ViewPlayer viewPlayer; 
        private ViewFPS viewFPS;

        public GameObject Person;
        public GameObject Weapon;
        private Terrain terrain;

        public float maxHealt;
        public float health;
        public float pWeaponDamage;
        public float mWeaponDamage;
        public float pDamage;
        public float mDamage;
        public float pDefence;
        public float mDefence;
        public string nameWeapon;
        public Vector3 velocity;
        public string state;

        void Awake()
        {
            controllerPersonage = new ControllerPersonage();

            viewCamera = transform.GetComponent<ViewCamera>();
            viewAnimator = transform.GetComponent<ViewAnimator>();
            viewPlayer = transform.GetComponent<ViewPlayer>();
            viewFPS = GameObject.FindGameObjectWithTag("tagFPS").gameObject.GetComponent<ViewFPS>();

            terrain = GameObject.FindGameObjectWithTag("tagTerrain").gameObject.GetComponent<Terrain>();
        }

        void Start()
        {
            controllerAnimator = transform.GetComponent<ViewAnimator>().controllerAnimator;

            controllerPersonage.AddObserver(controllerAnimator);
        }


        void Update()  
        {
            float hTerrain = terrain.SampleHeight(new Vector3(transform.position.x, 0, transform.position.z));
            controllerPersonage.SetHeightTerrain(hTerrain);

            if(controllerPersonage.GetPosition().y < -10) { TakeDamage(9999); }

            if (Person != null)
            {
                MovePersonage();
                RotatePersonage();
            }
        }

        public void ViewStatus()
        {
            ModelPersonage _mpState = new ModelPersonage();
            _mpState = controllerPersonage.GetPersonage();

            maxHealt = _mpState._maxHealth;
            health = _mpState._health;
            pWeaponDamage = _mpState._pWeaponDamage;
            mWeaponDamage = _mpState._mWeaponDamage;
            pDamage = _mpState._pDamage;
            mDamage = _mpState._mDamage;
            pDefence = _mpState._pDefence;
            mDefence = _mpState._mDefence;
            nameWeapon = _mpState._nameWeapon;
            velocity = _mpState._velocity;
            state = _mpState._nameState;

            Debug.Log("ViewStatus");
        }
        public void SetPersonage(GameObject pers)
        {
            Person = pers;
            controllerPersonage.SetState("isIdle");
        }
        public void SetWeapon(GameObject weap)
        {
            Weapon = weap;
            controllerPersonage.SetAttackState(false);
            controllerPersonage.SetState("isIdle");
        }
        
        /////////////////////////////////////////////////////
        public void InputMovePersonage(Vector2 inputMove)
        {
            controllerPersonage.InputMove(inputMove);
        }
        public void InputRotatePersonage(Vector2 inputRotate)
        {
            controllerPersonage.InputRotate(inputRotate);
 
        }
        public void InputAttack(string nameAttack)
        {
            if (controllerPersonage.GetState() != nameAttack)
            {
                Person.GetComponent<Animator>().applyRootMotion = true;
                controllerPersonage.Attack(nameAttack);
                ViewStatus();
            }
        }
        public void MovePersonage()
        {
            controllerPersonage.Move(Time.deltaTime); //Time.deltaTime //viewFPS.GetDeltaTime()

            Person.transform.Translate(controllerPersonage.GetAccelerateMove());
            controllerPersonage.SetPosition(Person.transform.position);
            ViewStatus();
        }
        public void RotatePersonage()
        {
            controllerPersonage.Rotate(Time.deltaTime); //Time.deltaTime //viewFPS.GetDeltaTime()

            Person.transform.localEulerAngles = new Vector3(0, GetAngleEuler().y, 0);
            viewCamera.SetRoteVer(GetAngleEuler().x);
        }
        public void AttackDisActive()
        {
            controllerPersonage.AttackDisActive();
            Person.GetComponent<Animator>().applyRootMotion = false;
        }

        /////////////////////////////////////////////////////
        public Vector3 GetPosition()
        {
            return controllerPersonage.GetPosition();
        }
        public Vector3 GetAngleEuler()
        {
            return controllerPersonage.GetAngleEuler();
        }
        public float GetDamage()
        {
            return controllerPersonage.GetDamage();
        }
        public string GetName()
        {
            return controllerPersonage.GetName();
        }

        /////////////////////////////////////////////////////
        public Vector3 SpawnPersonage()
        {
            Vector3 vec = controllerPersonage.SpawnRandom();
            float terrainY = terrain.SampleHeight(new Vector3(vec.x, 0, vec.y));
            controllerPersonage.InitPersonage(new Vector3(vec.x, terrainY + vec.y, vec.z));

            return controllerPersonage.GetPosition();
        }

        /////////////////////////////////////////////////////
        public void TakeDamage(float hitDamage)
        {
            controllerPersonage.TakeDamage(hitDamage);

            if (controllerPersonage.GetDeathState() == true)
            {
                Person.transform.position = SpawnPersonage();
            }
            ViewStatus();
        }
    }
}
