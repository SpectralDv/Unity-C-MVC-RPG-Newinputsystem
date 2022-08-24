using System.Collections;
using System.Collections.Generic;
using System.Linq; //FindObjectsOfType
using UnityEngine;


using Controller.Player;
using View.uAnimator;
namespace View
{
    public class ViewPlayer : MonoBehaviour
    {
        //private Terrain terrain;
        [SerializeField]
        private int numPlayer = 0;
        [SerializeField]
        private GameObject Person;
        [SerializeField]
        private GameObject Weapon;

        //[HideInInspector]
        private ControllerPlayer controllerPlayer;
        private ViewPersonage viewPersonage;
        private ViewAnimator viewAnimator;
        [HideInInspector]
        public ViewVisiblePanel viewVisiblePanel;

        private Vector2 moveVector = Vector2.zero;
        private Vector2 rotateVector = Vector2.zero;

        void Awake()
        {
            controllerPlayer = new ControllerPlayer();

            viewPersonage = transform.GetComponent<ViewPersonage>();
            viewAnimator = transform.GetComponent<ViewAnimator>();

            var viewVisiblePanels = FindObjectsOfType<ViewVisiblePanel>();
            viewVisiblePanel = viewVisiblePanels.FirstOrDefault(m => m.GetNumPlayer() == numPlayer);
            viewVisiblePanel.DisActiveVisiblePanel();

            //terrain = GameObject.FindGameObjectWithTag("tagTerrain").gameObject.GetComponent<Terrain>();

            //fps = GameObject.FindGameObjectWithTag("tagCanvas").gameObject.transform.Find("FPS").GetComponent<FPS>();
        }

        //////////////////////////////
        public void SetPersonage(GameObject obj)
        {
            SpawnPersonage(obj);
            transform.GetComponent<ViewPersonage>().SetPersonage(Person);

            transform.GetComponent<ViewCamera>().SetPersonage(Person);
        }
        public void SetWeapon(GameObject obj,string nameWeapon)
        {
            if (Person != null)
            {
                if (Weapon != null) { Destroy(Weapon.gameObject); }

                Vector3 vec = Person.transform.position;
                Weapon = Instantiate<GameObject>(obj, vec, Person.transform.localRotation);
                Weapon.transform.SetParent(Person.transform.gameObject.transform);

                RuntimeAnimatorController anim = viewAnimator.GetAnim(nameWeapon);

                Person.GetComponent<Animator>().runtimeAnimatorController = anim;
                Weapon.GetComponent<Animator>().runtimeAnimatorController = anim;

                viewAnimator.GetAnimator(Person.GetComponent<Animator>(), Weapon.GetComponent<Animator>());

                transform.GetComponent<ViewPersonage>().SetWeapon(Weapon);

                Weapon.transform.GetComponent<ViewAttack>().SetParantObject(transform.gameObject);
                Weapon.GetComponent<ViewAttack>().SetNameViewModel("ViewPersonage");
            }
        }
        ///////////////////////////
        public int GetNumPlayer()
        {
            return numPlayer;
        }
        //////////////////////////////
        public void InputVectorMove(Vector2 vectorValue)
        {
            moveVector = vectorValue;

            viewPersonage.InputMovePersonage(vectorValue);
        }
        public void InputVectorRotate(Vector2 vectorValue)
        {
            rotateVector = vectorValue;

            viewPersonage.InputRotatePersonage(vectorValue);
        }
        //////////////////////////////////////
        public void SpawnPersonage(GameObject objSpawn)
        {
            if (Person != null) { Destroy(Person.gameObject); }

            Vector3 corSpawn = viewPersonage.SpawnPersonage();

            //рандомные значения для угла
            //Quaternion quatY =  Quaternion.Euler(0,randomValueY,0);
            //Quaternion quatY = Quaternion.Euler(0, 0, 0);

            //спавн(кого спавнит, где спавнить)
            Person = Instantiate<GameObject>(objSpawn, corSpawn, Quaternion.identity);
            Person.transform.SetParent(transform.gameObject.transform);

            Person.transform.GetComponent<ViewTakeDamage>().SetParantObject(transform.gameObject);
            Person.GetComponent<ViewTakeDamage>().SetNameViewModel("ViewPersonage");
        }
    }
}
