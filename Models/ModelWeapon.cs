using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Slot;
using Weapon;
namespace Model.Weapon
{

    public class ModelWeapon : IWeapon
    {
        public string _nameModel { get; set; }
        public float _pDamage { get; set; }
        public float _mDamage { get; set; }
        public float _countSlot { get; set; }
        public float _speedWeapon { get; set; }

        public void TakeInSlot(ITake o) { }
        public void DropFromSlot(IDrop o) { }
    }

}
