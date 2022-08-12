using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace View
{
    public class ViewAttack : MonoBehaviour
    {
        public GameObject ParantObject;

        public string _nameViewModel;

        public GameObject RightHand;
        public GameObject LeftHand;

        UnityEvent eventSwig = new UnityEvent();
        UnityEvent eventActiveCollider = new UnityEvent();
        UnityEvent eventDisActiveColleder = new UnityEvent();
        UnityEvent eventAttackEnd = new UnityEvent();


        public AudioSource HitSound;

        void Start()
        {
            eventSwig.AddListener(animSwig);
            eventActiveCollider.AddListener(animActiveCollider);
            eventDisActiveColleder.AddListener(animDisActiveCollider);
            eventAttackEnd.AddListener(animAttackEnd);
        }


        public void SetParantObject(GameObject parantObject)
        {
            ParantObject = parantObject;

            RightHand = transform.Find("Motion/B_Pelvis/B_Spine/B_Spine1/B_R_Clavicle/B_R_UpperArm/B_R_Forearm/B_R_Hand/RayRight").gameObject;
            LeftHand = transform.Find("Motion/B_Pelvis/B_Spine/B_Spine1/B_L_Clavicle/B_L_UpperArm/B_L_Forearm/B_L_Hand/RayLeft").gameObject;
        }

        public void SetNameViewModel(string nameViewModel)
        {
            _nameViewModel = nameViewModel;
        }

        public void HitDamage()
        {
            if (_nameViewModel == "ViewPersonage")
            {
                float damage = ParantObject.GetComponent<ViewPersonage>().GetDamage();
                string nameAttacker = ParantObject.GetComponent<ViewPersonage>().GetName();

                if (RightHand.transform.GetComponent<ViewTriggerAttack>() != null)
                {
                    RightHand.transform.GetComponent<ViewTriggerAttack>().SetDamage(damage);
                    RightHand.transform.GetComponent<ViewTriggerAttack>().SetNameAttacker(nameAttacker);
                }
                if (LeftHand.transform.GetComponent<ViewTriggerAttack>() != null)
                {
                    LeftHand.transform.GetComponent<ViewTriggerAttack>().SetDamage(damage);
                    RightHand.transform.GetComponent<ViewTriggerAttack>().SetNameAttacker(nameAttacker);
                }
            }
            if (_nameViewModel == "ViewEnemy")
            {
                float damage = ParantObject.GetComponent<ViewEnemy>().GetDamage();
                RightHand.transform.GetComponent<ViewTriggerAttack>().SetDamage(damage);
            }
            if (_nameViewModel == "ViewBoss")
            {
                float damage = ParantObject.GetComponent<ViewBoss>().GetDamage();
                RightHand.transform.GetComponent<ViewTriggerAttack>().SetDamage(damage);
            }
        }


        /////////////////////////////////////////////////////////
        public void animSwig()
        {
            HitSound.Play(); // PlayOneShot(); //Play(); 
        }

        public void animActiveCollider()
        {
            HitDamage();
            RightHand.GetComponent<ViewTriggerAttack>().ActiveCollider();
            LeftHand.GetComponent<ViewTriggerAttack>().ActiveCollider();
        }

        public void animDisActiveCollider()
        {
            RightHand.GetComponent<ViewTriggerAttack>().DisActiveCollider();
            LeftHand.GetComponent<ViewTriggerAttack>().DisActiveCollider();
        }

        public void animAttackEnd()
        {
            if (_nameViewModel == "ViewPersonage")
            {
                ParantObject.GetComponent<ViewPersonage>().AttackDisActive();
            }
            if (_nameViewModel == "ViewEnemy")
            {
                //ParantObject.GetComponent<ViewEnemy>().AttackDisActive();
            }
            if (_nameViewModel == "ViewBoss")
            {
                //ParantObject.GetComponent<ViewBoss>().AttackDisActive();
            }
        }

    }
}
