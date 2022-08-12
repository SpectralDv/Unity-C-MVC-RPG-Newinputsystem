using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using SpaceAnimator;
using Model;
using Observer;
using Slot;
using Weapon;
namespace Personage
{
    enum PersonageSlots
    {
        RightHand,
        LeftHand,
        Head,
        UpBody,
        DownBody,
        RightFoot,
        LeftFoot
    }

    enum InventorySlots
    {
        Slot1,
        Slot2,
        Slot3,
        Slot4
    }

    public interface IControllerPersonage : IObserverWeapon, IObservable
    {

    }

    public class ControllerPersonage : IControllerPersonage
    {
        public ModelPersonage _mp;
        private List<ModelSlot> _listlSlot;
        private List<IObserver> _observers;

        public ControllerPersonage()
        {
            _mp = new ModelPersonage();
            _observers = new List<IObserver>();
            _listlSlot = new List<ModelSlot>();

            foreach (var i in Enum.GetValues(typeof(PersonageSlots)))
            {
                _listlSlot.Add(new ModelSlot { _nameModel = i.ToString(), _slot = (ISlot)(new ModelSlot()) });
            }

            InitPersonage(new Vector3(0,0,0));

            Debug.Log("ControllerPersonage");
        }

        private void SetNamePersonage(string namePersonage) { _mp._nameModel = namePersonage; }
        private void SetNameWeapon(string nameWeapon) { _mp._nameWeapon = nameWeapon; }
        private void SetPosRightHand(Vector3 vec) { _mp._posRightHand = vec; }
        private void SetPosLeftHand(Vector3 vec) { _mp._posLeftHand = vec; }
        private void SetMaxHealth(float maxHealth) { _mp._maxHealth = maxHealth; }
        private void SetHealth(float health) { _mp._health = health; }
        private void SetPDamage(float pDamage) { _mp._pDamage = pDamage; }
        private void SetMDamage(float mDamage) { _mp._mDamage = mDamage; }
        private void SetPDefence(float pDefence) { _mp._pDefence = pDefence; }
        private void SetMDefence(float mDefence) { _mp._mDefence = mDefence; }
        private void TakePDamage(float takePDamage) { _mp._takePDamage = takePDamage; }
        private void TakeMDamage(float takeMDamage) { _mp._takeMDamage = takeMDamage; }
        private void SetMoveSpeed(float speedMove) { _mp._speedMove = speedMove; }
        private void SetRotateSpeed(float speedRotate) { _mp._speedRotate = speedRotate; }
        private void SetAngleEuler(Vector3 angleEuler) { _mp._angleEuler = angleEuler; }
        private void SetDeathState(bool deathState) { _mp._deathState = deathState; }
        private void SetHeightSpawn(float hSpawn) { _mp._hSpawn = hSpawn; }

        public void SetPosition(Vector3 position) { _mp._position = position; }
        public void SetHeightTerrain(float hTerrain) { _mp._hTerrain = hTerrain; }
        public void SetState(string nameState) { _mp._nameState = nameState; }
        public void SetAttackState(bool attackState) { _mp._attackState = attackState; }

        public string GetName() { return _mp._nameModel;  }
        public string GetNameWeapon() { return _mp._nameWeapon; }
        public Vector3 GetPosition() { return _mp._position; }
        public Vector3 GetAngleEuler() { return _mp._angleEuler; }
        public float GetSpeedMove() { return _mp._speedMove; }
        public float GetSpeedRotate() { return _mp._speedRotate; }
        public Vector3 GetAccelerateMove() { return _mp._accelerateMove; }
        public float GetAccelerateRoteY() { return _mp._accelerateRoteY; }
        public string GetState() { return _mp._nameState; }
        public ModelPersonage GetPersonage() { return _mp;}
        public float GetDamage() { return _mp._pWeaponDamage; }
        public bool GetDeathState() { return _mp._deathState; }

        public void InitPersonage(Vector3 vecPos)
        {
            SetNamePersonage("unknown");
            SetNameWeapon("none");
            SetPosRightHand(new Vector3(0, 0, 0));
            SetPosLeftHand(new Vector3(0, 0, 0));
            SetMaxHealth(100);
            SetHealth(100);
            SetPDamage(0);
            SetMDamage(0);
            SetPDefence(0);
            SetMDefence(0);
            TakePDamage(0);
            TakeMDamage(0);
            SetMoveSpeed(1);
            SetRotateSpeed(1);
            SetPosition(vecPos);
            SetAngleEuler(new Vector3(0, 0, 0));
            SetState("isIdle");
            SetAttackState(false);
            SetDeathState(false);
            SetHeightSpawn(2);
        }

        ////////////////////////////////////////////////
        public void AddObserver(IObserver o)
        {
            _observers.Add((IObserverAnimator)o);
        }
        public void RemoveObserver(IObserver io)
        {
            foreach (IObserverAnimator o in _observers)
            {
                if (io == o) { _observers.Remove(o); break; }
            }
        }
        public void notify(KeyValuePair<string, IModel> p)
        {
            if (p.Key == "animator")
            {
                foreach (IObserverAnimator o in _observers)
                {
                    int ret = o.ChangeAnimState(p.Value._nameModel, _mp._speedAnim);
                }
            }
        }

        //////////////////////////////////////////////
        public float Phisic()
        {
            if (_mp._hTerrain < _mp._position.y)
            {
                return -0.5f;
            }
            return 0;
        }

        //////////////////////////////////////////////
        public void Move(float deltaTime)
        {
            _mp._accelerateMove = new Vector3(_mp._inputMove.x, 0, _mp._inputMove.y) * _mp._speedMove * deltaTime;//0.03f;//
            _mp._velocity = _mp._accelerateMove;

            if (_mp._attackState == true)
            {
                _mp._accelerateMove = new Vector3(0, 0, 0);
            }

            if (_mp._attackState == false && _mp._deathState == false )
            {
                if (_mp._accelerateMove != new Vector3(0, 0, 0))
                {
                    _mp._nameState = "isRun";
                    KeyValuePair<string, IModel> p = new KeyValuePair<string, IModel>("animator", new ModelAnimator { _nameModel = "isRun" });
                    _mp._speedAnim = 1;
                    notify(p);
                }
                else if (_mp._accelerateMove == new Vector3(0, 0, 0))
                {
                    _mp._nameState = "isIdle";
                    KeyValuePair<string, IModel> p = new KeyValuePair<string, IModel>("animator", new ModelAnimator { _nameModel = "isIdle" });
                    _mp._speedAnim = 1;
                    notify(p);
                }
            }
        }
        public void Rotate(float deltaTime)
        {
            float rotationY = _mp._angleEuler.y + _mp._inputRotate.y * _mp._speedRotate;

            _mp._accelerateRoteY = _mp._inputRotate.y * _mp._speedRotate;
            _mp._angleEuler = new Vector3(_mp._inputRotate.x, rotationY, 0);
        }

        //////////////////////////////////////////////
        public void Attack(string nameAttack)
        {
            _mp._attackState = true;
            _mp._nameState = nameAttack;
            _mp._speedAnim = _mp._speedWeapon;
            KeyValuePair<string, IModel> p = new KeyValuePair<string, IModel>("animator", new ModelAnimator { _nameModel = "isAttack1" });
            notify(p);
        }
        public void AttackDisActive()
        {
            _mp._attackState = false;
        }

        //////////////////////////////////////////////
        private void TakeSlot(string nameSlot, ISlot slotRightHand)
        {
            _listlSlot.Find(x => x._nameModel.Contains(nameSlot))._slot = slotRightHand;
        }
        private void DropSlot(string nameSlot)
        {
            _listlSlot.Remove(_listlSlot.Find(x => x._nameModel.Contains(nameSlot)));
        }

        //////////////////////////////////////////////
        public int AddWeapon(ModelWeapon mw)
        {
            _mp._nameWeapon = mw._nameModel;
            _mp._pWeaponDamage = mw._pDamage;
            _mp._mWeaponDamage = mw._mDamage;
            _mp._speedWeapon = mw._speedWeapon;

            if (mw._countSlot == 1)
            {
                TakeSlot("RightHand", (ISlot)mw);
            }
            if (mw._countSlot == 2)
            {
                TakeSlot("RightHand", (ISlot)mw);
                TakeSlot("LeftHand", (ISlot)mw);
            }

            return 0;
        }
        public void RemoveWeapon(string nameSlot)
        {
            DropSlot(nameSlot);
        }

        ////////////////////////////////////////////////
        public void InputMove(Vector2 inputMove)
        {
            if (_mp._countFrame < 50) { _mp._speedMove = 6; }
            if (_mp._countFrame > 50) { _mp._speedMove = 2; }

            _mp._inputMove = inputMove;
        }
        public void InputRotate(Vector2 inputRotate)
        {
            if (_mp._countFrame < 50) { _mp._speedRotate = 3; }
            if (_mp._countFrame > 50) { _mp._speedRotate = 1; }

            _mp._inputRotate = inputRotate;
        }

        ////////////////////////////////////////////////
        public void TakeDamage(float hitDamage)
        {
            float cleanDamage = hitDamage - _mp._pDefence;
            if (cleanDamage < 1) { cleanDamage = 1; }
            _mp._health -= cleanDamage;
            if(_mp._health <= 0) { _mp._deathState = true; }
        }
        /////////////////////////////////////////////////////
        public Vector3 SpawnRandom()
        {
            int randomValueX = UnityEngine.Random.Range(-5, 5);
            int randomValueZ = UnityEngine.Random.Range(-5, 5);
            //int randomValueY = Random.Range(-180, 180);

            Vector3 contrPoint = new Vector3(10, 0, 10);

            float posX = contrPoint.x + randomValueX;
            float posZ = contrPoint.z + randomValueZ;

            Vector3 corSpawn = new Vector3(posX, _mp._hSpawn, posZ);

            SetPosition(corSpawn);

            return corSpawn;
        }

    }
}
