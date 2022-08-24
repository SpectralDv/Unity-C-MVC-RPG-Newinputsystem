using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Personage;
namespace Model.Personage
{
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

        public float _level { get; set; }
        public float _expPersonage { get; set; }
        public float _expNextLevel { get; set; }

        public float _heartiness { get; set; } //количество здоровья
        public float _intelegence { get; set; } //количество маны
        public float _strange { get; set; } //количество силы 
        public float _dexterity { get; set; } //количество ловкости 
        public float _edurance { get; set; } //количество выносливости 
        public float _faith { get; set; } //вера, количество магической силы для восстановления здоровья
        public float _arcane { get; set; } //колдовтсво, количество магической силы
        public float _spirit { get; set; } //дух, скорость восстановления здоровья 
        public float _mind { get; set; } //мудрость, скорость восстановления маны 
        public float _stamina { get; set; } //скорость восстановления выносливости 

        public float _lightAddress { get; set; } //бонус к ношению легкой брони
        public float _mediumAddress { get; set; } //бонус к ношению средней брони
        public float _havyAddress { get; set; } //бонус к ношению тяжелой брони


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
