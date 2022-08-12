using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


using TakeDamage;
namespace View
{
    enum eViewTakeDamage
    {
        ViewPersonage,
        ViewEnemy,
        ViewBoss
    }

    public class ViewTakeDamage : MonoBehaviour
    {
        public GameObject ParantObject;

        private ControllerTakeDamage controllerTakeDamage;

        public string _nameViewTaker;

        UnityEvent eventSwig = new UnityEvent();
        UnityEvent eventActiveCollider = new UnityEvent();
        UnityEvent eventDisActiveColleder = new UnityEvent();
        UnityEvent eventAttackEnd = new UnityEvent();

        void Awake()
        {
            controllerTakeDamage = new ControllerTakeDamage();
        }

        void Start()
        {
            eventSwig.AddListener(animSwig);
            eventActiveCollider.AddListener(animActiveCollider);
            eventDisActiveColleder.AddListener(animDisActiveCollider);
            eventAttackEnd.AddListener(animAttackEnd);
        }


        public void animActiveCollider() { }
        public void animDisActiveCollider() { }
        public void animAttackEnd() { } 
        public void animSwig() { }

        public void SetParantObject(GameObject parantObject)
        {
            ParantObject = parantObject;
        }

        public void SetNameViewModel(string nameViewModel)
        {
            _nameViewTaker = nameViewModel;
        }


        public int TakeDamage(string nameAttacker, float hitDamage)
        {
            //controllerTakeDamage.FindViewTakeDamage(_nameViewTaker);

            if (_nameViewTaker == "ViewPersonage")
            {
                ParantObject.GetComponent<ViewPersonage>().TakeDamage(hitDamage);
            }
            if (_nameViewTaker == "ViewEnemy")
            {
                ParantObject.GetComponent<ViewEnemy>().TakeDamage(hitDamage);
            }
            if (_nameViewTaker == "ViewBoss")
            {
                ParantObject.GetComponent<ViewBoss>().TakeDamage(hitDamage);
            }

            return 0;
        }



    }
}