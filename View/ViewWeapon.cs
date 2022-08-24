using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Model.Weapon;
using Controller.Personage;
using Controller.Weapon;
namespace View
{
    public class ViewWeapon : MonoBehaviour
    {
        public float PlayerIndex;

        public GameObject OneHandSword;
        public GameObject TwoHandSword;
        public GameObject Spear;
        public GameObject Hammer;
        public GameObject TwoSwords;

        private ViewPlayer viewPlayer;
        private ViewPersonage viewPersonage;

        //[HideInInspector]
        public ControllerWeapon controllerWeapon;
        private ControllerPersonage controllerPersonage;

        void Awake()
        {
            controllerWeapon = new ControllerWeapon();

            viewPersonage = transform.GetComponent<ViewPersonage>();
            viewPlayer = transform.GetComponent<ViewPlayer>();
        }

        void Start()
        {
            controllerPersonage = transform.GetComponent<ViewPersonage>().controllerPersonage;

            controllerWeapon.AddObserver(controllerPersonage);
        }

        public void ChangeWeapon(GameObject weapon, string nameWeapon, float pDamage, float mDamage, float countSlot, float speedWeapon)
        {
            if (controllerWeapon.GetListWeapon() != null)
            {
                controllerWeapon.ClearListWeapon();
            }

            controllerWeapon.AddListWeapon(nameWeapon, pDamage, mDamage, countSlot, speedWeapon);
            ModelWeapon mw = controllerWeapon.GetModelWeapon(nameWeapon);
            viewPlayer.SetWeapon(weapon, nameWeapon);
            KeyValuePair<string, IModel> p = new KeyValuePair<string, IModel>("weapon", mw);
            controllerWeapon.notify(p);

            viewPersonage.ViewStatus();
        }

        public void ButtonOneHandWeapon()
        {
            ChangeWeapon(OneHandSword,"OneHandSword", 60, 0, 1, 0.9f);
        }
        public void ButtonTwoHandWeapon()
        {
            ChangeWeapon(TwoHandSword,"TwoHandSword", 120, 0, 2, 0.9f);
        }
        public void ButtonSpearWeapon()
        {
            ChangeWeapon(Spear,"Spear", 90, 0, 2, 0.9f);
        }
        public void ButtonHammerWeapon()
        {
            ChangeWeapon(Hammer,"Hammer", 110, 0, 2, 0.9f);
        }
        public void ButtonTwoSwordsWeapon()
        {
            ChangeWeapon(TwoSwords,"TwoSwords", 60, 0, 2, 0.9f);
        }

    }
}
