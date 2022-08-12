using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Slot;
namespace Personage
{
    public class ModelSlot : ISlot
    {
        public string _nameModel { get; set; }
        public ISlot _slot { get; set; }
    }

    public class ModelPersonage : IPersonage
    {
        public string _nameModel { get; set; }
        public Vector3 _posRightHand { get; set; }
        public Vector3 _posLeftHand { get; set; }
        public string _nameWeapon { get; set; }
        public float _maxHealth { get; set; }
        public float _health { get; set; }
        public float _pDamage { get; set; }
        public float _mDamage { get; set; }
        public float _pDefence { get; set; }
        public float _mDefence { get; set; }
        public float _takePDamage { get; set; }
        public float _takeMDamage { get; set; }
        public float _countDeath { get; set; }

        public float _speedAnim { get; set; }
        public float _speedWeapon { get; set; }
        public float _pWeaponDamage { get; set; }
        public float _mWeaponDamage { get; set; }

        public float _hSpawn { get; set; }
        public float _hTerrain { get; set; }
        public float _speedMove { get; set; }
        public float _speedRotate { get; set; }
        public Vector3 _position { get; set; }
        public Vector3 _angleEuler { get; set; }

        public float _deltaTime { get; set; }
        public float _sTimer { get; set; }
        public float _countFrame { get; set; }

        public Vector3 _inputMove { get; set; }
        public Vector3 _inputRotate { get; set; }

        public Vector3 _accelerateMove { get; set; }
        public float _accelerateRoteY { get; set; }
        public Vector3 _velocity { get; set; }

        public string _nameState { get; set; }
        public string _strState { get; set; }
        public bool _attackState { get; set; }
        public bool _deathState { get; set; }


        public void AddHeaddress() { }
        public void RemoveHeaddres() { }
        public void AddUpBodyaddress() { }
        public void RemoveUpBodyaddress() { }
        public void AddDownBodyaddress() { }
        public void RemoveDownBodyaddress() { }

        public void AddRightFootAddress() { }
        public void RemoveRightFootAddress() { }
        public void AddLeftFootAddress() { }
        public void RemoveLeftFootAddress() { }
    }
}
