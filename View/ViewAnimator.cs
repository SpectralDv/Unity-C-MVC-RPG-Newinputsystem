using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Player;
using uAnimator;
using Model.uAnimator;
using Controller.uAnimator;
namespace View.uAnimator
{
    public class ViewAnimator : MonoBehaviour
    {
        public ControllerAnimator controllerAnimator;

        public Animator animaPersonage;
        public Animator animaWeapon;

        public RuntimeAnimatorController animOneHand;
        public RuntimeAnimatorController animTwoHand;
        public RuntimeAnimatorController animSpear;
        public RuntimeAnimatorController animHammer;
        public RuntimeAnimatorController animTwoSwords;

        public string predStrAnim;


        void Awake()
        {
            controllerAnimator = new ControllerAnimator();
            predStrAnim = "isIdle";
        }


        void Update()
        {
            if (animaPersonage != null)
            {
                string strAnim = controllerAnimator.GetAnimState(); //error

                if (strAnim != predStrAnim)
                {
                    predStrAnim = strAnim;
                    UpdateAnimator(strAnim);
                }
            }
        }

        public void GetAnimator(Animator animPers, Animator animWeap)
        {
            animaPersonage = animPers;
            animaWeapon = animWeap;
        }

        public RuntimeAnimatorController GetAnim(string nameWeapon)
        {
            if (nameWeapon == "OneHandSword")
            {
                return animOneHand;
            }
            if (nameWeapon == "TwoHandSword")
            {
                return animTwoHand;
            }
            if (nameWeapon == "Spear")
            {
                return animSpear;
            }
            if (nameWeapon == "Hammer")
            {
                return animHammer;
            }
            if (nameWeapon == "TwoSwords")
            {
                return animTwoSwords;
            }
            return animOneHand;
        }

        private void UpdateAnimator(string nameAnimator)
        {
            animaPersonage.speed = controllerAnimator.GetAnimSpeed(); 
            animaWeapon.speed = controllerAnimator.GetAnimSpeed();

            if (nameAnimator == "isAttack1")
            {
                animaPersonage.SetTrigger("Attack1");
                animaWeapon.SetTrigger("Attack1");
            }
            if (nameAnimator == "isRun")
            {
                animaPersonage.SetTrigger("Run");
                animaWeapon.SetTrigger("Run");
            }
            if (nameAnimator == "isIdle")
            {
                animaPersonage.SetTrigger("Idle");
                animaWeapon.SetTrigger("Idle");
            }
        }

    }
}
