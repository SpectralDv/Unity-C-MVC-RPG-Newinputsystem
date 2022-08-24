using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Slot;
using Player;
using Weapon;
using uAnimator;
using View.uAnimator;
using Controller.uAnimator;
using Controller.Personage;
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
        private ViewVisiblePanel viewVisiblePanel;

        public GameObject Person;
        public GameObject Weapon;
        private Terrain terrain;

        public float maxHealth;
        public float health;
        public float pWeaponDamage;
        public float mWeaponDamage;
        public float pDamage;
        public float mDamage;
        public float pDefence;
        public float mDefence;
        public string nameWeapon;
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
            viewVisiblePanel = viewPlayer.viewVisiblePanel;

            controllerAnimator = transform.GetComponent<ViewAnimator>().controllerAnimator;

            controllerPersonage.AddObserver(controllerAnimator);
        }


        void FixedUpdate()  
        {
            float hTerrain = terrain.SampleHeight(new Vector3(transform.position.x, 0, transform.position.z));
            controllerPersonage.UpdateCharacter("HTerrain", hTerrain);
            //controllerPersonage.SetHeightTerrain(hTerrain);

            if (controllerPersonage.GetCharacter("Position",new Vector3()).y < -10) { TakeDamage(99999); }
            //if (controllerPersonage.GetPosition().y < -10) { TakeDamage(99999); }

            if (Person != null)
            {
                MovePersonage();
                RotatePersonage();
            }
        }

        public void ViewStatus()
        {
            maxHealth = controllerPersonage.GetCharacter("MaxHelth", 0);
            health = controllerPersonage.GetCharacter("Health", 0);
            pWeaponDamage = controllerPersonage.GetCharacter("PWeaponDamage", 0);
            mWeaponDamage = controllerPersonage.GetCharacter("MWeaponDamage", 0);
            pDamage = controllerPersonage.GetCharacter("PDamage", 0);
            mDamage = controllerPersonage.GetCharacter("MDamage", 0);
            pDefence = controllerPersonage.GetCharacter("PDefence", 0);
            mDefence = controllerPersonage.GetCharacter("MDefence", 0);
            nameWeapon = controllerPersonage.GetCharacter("NameWeapon", "");
            state = controllerPersonage.GetCharacter("AnimState", "");


            viewVisiblePanel.ViewHealth(maxHealth, health);

            Debug.Log("ViewStatus");
        }
        public void SetPersonage(GameObject pers)
        {
            Person = pers;
            controllerPersonage.UpdateCharacter("AnimState", "isIdle");
            //controllerPersonage.SetState("isIdle");
        }
        public void SetWeapon(GameObject weap)
        {
            Weapon = weap;
            controllerPersonage.UpdateCharacter("AnimState", "isIdle");
            controllerPersonage.UpdateCharacter("AttackState", false);

            //controllerPersonage.SetAttackState(false);
            //controllerPersonage.SetState("isIdle");
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
            if (controllerPersonage.GetCharacter("AnimState", "") != nameAttack)
            {
                Person.GetComponent<Animator>().applyRootMotion = true;
                controllerPersonage.Attack(nameAttack);
                ViewStatus();
            }
        }
        public void MovePersonage()
        {
            controllerPersonage.Move(Time.deltaTime); //Time.deltaTime //viewFPS.GetDeltaTime()

            Person.transform.Translate(controllerPersonage.GetCharacter("AccelerateMove",new Vector3(0,0,0)));
            controllerPersonage.UpdateCharacter("Position",Person.transform.position);
            //controllerPersonage.SetPosition(Person.transform.position);
            //ViewStatus();
        }
        public void RotatePersonage()
        {
            controllerPersonage.Rotate(Time.deltaTime); //Time.deltaTime //viewFPS.GetDeltaTime()

            Person.transform.localEulerAngles = new Vector3(0, controllerPersonage.GetCharacter("AngleEuler", new Vector3(0,0,0)).y, 0);
            viewCamera.SetRoteVer(controllerPersonage.GetCharacter("AngleEuler", new Vector3(0, 0, 0)).x);
        }
        public void AttackDisActive()
        {
            controllerPersonage.AttackDisActive();
            Person.GetComponent<Animator>().applyRootMotion = false;
        }

        /////////////////////////////////////////////////////
        public Vector3 GetPosition()
        {
            return controllerPersonage.GetCharacter("Position",new Vector3());
            //return controllerPersonage.GetPosition();
        }
        public Vector3 GetAngleEuler()
        {
            return controllerPersonage.GetCharacter("AngleEuler",new Vector3());
            //return controllerPersonage.GetAngleEuler();
        }
        public float GetDamage()
        {
            return controllerPersonage.DefineDamage();
        }
        public string GetName()
        {
            return controllerPersonage.GetCharacter("NameModel", "");
        }

        /////////////////////////////////////////////////////
        public Vector3 SpawnPersonage()
        {
            Vector3 vec = controllerPersonage.SpawnRandom();
            float terrainY = terrain.SampleHeight(new Vector3(vec.x, 0, vec.y));
            controllerPersonage.InitPersonage(new Vector3(vec.x, terrainY + vec.y, vec.z));

            return controllerPersonage.GetCharacter("Position",new Vector3());
            //return controllerPersonage.GetPosition();
        }

        /////////////////////////////////////////////////////
        public void TakeDamage(float hitDamage)
        {
            controllerPersonage.TakeDamage(hitDamage);

            if (controllerPersonage.GetCharacter("DeathState", true) == true)
            {
                Person.transform.position = SpawnPersonage();
            }
            ViewStatus();
        }
    }
}
