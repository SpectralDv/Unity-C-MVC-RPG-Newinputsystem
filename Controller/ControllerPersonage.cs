using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Observer;
using Slot;
using Model.Slot;
using Model.uAnimator;
using Model.Weapon;
using Model.Character;
using Model.Personage;
using Controller.Level;
namespace Controller.Personage
{
    enum eCharacter
    {
        NameModel,
        PosRightHand,
        PosLeftHand,
        NameWeapon,
        MaxHelth,
        Health,
        PDamage,
        MDamage,
        PDefence,
        MDefence,
        TakeDamage,
        TakePDamage,
        TakeMdamage,
        Level,
        ExpPersonage,
        ExpNextLevel,
        Heartiness,
        Intelegence,
        Strange,
        Dexterity,
        Edurance,
        Faith,
        Arcane,
        Spirit,
        Mind,
        Stamina,
        LightAddress,
        MediumAddress,
        HavyAddress,
        SpeedAnim,
        SpeedWeapon,
        PWeaponDamage,
        MWeaponDamage,
        HSpawn,
        HTerrain,
        SpeedMove, 
        SpeedRotate,
        Position,
        AngleEuler,
        CountFrame, 
        InputMove, 
        InputRotate, 
        AccelerateMove, 
        AccelerateRoteY, 
        AnimState, 
        StrState, 
        AttackState,
        DeathState 
    };

    enum ePersonageSlot
    {
        RightHand,
        LeftHand,
        Head,
        UpBody,
        DownBody,
        RightFoot,
        LeftFoot
    }

    enum eInventorySlot
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
        //public ModelPersonage _mp;
        private List<ModelCharacter> _listCharacter;
        private List<ModelSlot> _listlSlot;
        private List<IObserver> _observers;

        public ControllerPersonage()
        {
            //_mp = new ModelPersonage();
            _listCharacter = new List<ModelCharacter>();
            _listlSlot = new List<ModelSlot>();
            _observers = new List<IObserver>();

            foreach (var i in Enum.GetValues(typeof(eCharacter)))
            {
                _listCharacter.Add(new ModelCharacter{_nameModel = i.ToString(),_value = 0, _string = "",_vector = new Vector3(0,0,0), _event=false});
            }

            foreach (var i in Enum.GetValues(typeof(ePersonageSlot)))
            {
                _listlSlot.Add(new ModelSlot { _nameModel = i.ToString(), _slot = (ISlot)(new ModelSlot()) });
            }

            InitPersonage(new Vector3(0,0,0));

            Debug.Log("ControllerPersonage");
        }

        ////////////////////////////////////////////////
        public void UpdateCharacter(string nameCharacter, float value)
        {
            _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._value = value;
        }
        public void UpdateCharacter(string nameCharacter, string text)
        {
            _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._string = text;
        }
        public void UpdateCharacter(string nameCharacter, Vector3 vector)
        {
            _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._vector = vector;
        }
        public void UpdateCharacter(string nameCharacter, bool event_)
        {
            _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._event = event_;
        }
        public float GetCharacter(string nameCharacter, float value)
        {
            return _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._value;
        }
        public string GetCharacter(string nameCharacter, string text)
        {
            return _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._string; 
        }
        public Vector3 GetCharacter(string nameCharacter, Vector3 vector)
        {
            return _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._vector;
        }
        public bool GetCharacter(string nameCharacter, bool event_)
        {
            return _listCharacter.Find(x => x._nameModel.Contains(nameCharacter))._event;
        }

        ////////////////////////////////////////////////
        public void InitPersonage(Vector3 vecPos)
        {
            UpdateCharacter("MaxHelth", 100);
            UpdateCharacter("Health",100);
            UpdateCharacter("SpeedMove", 5);
            UpdateCharacter("SpeedRotate", 100);
            UpdateCharacter("Position", vecPos);
            UpdateCharacter("AnimState", "isIdle");
            UpdateCharacter("HSpawn",2);
            UpdateCharacter("AttackState", false);
            UpdateCharacter("DeathState", false);
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
                    int ret = o.ChangeAnimState(p.Value._nameModel, GetCharacter("SpeedAnim",0));
                }
            }
        }

        //////////////////////////////////////////////
        public float Phisic()
        {
            if (GetCharacter("HTerrain",0) < GetCharacter("Position",new Vector3()).y)
            {
                return -0.5f;
            }
            return 0;
        }

        //////////////////////////////////////////////
        public void Move(float deltaTime)
        {
            Vector3 v = new Vector3(0,0,0);

            UpdateCharacter("AccelerateMove", new Vector3(
                GetCharacter("InputMove",v).x, 
                0,
                GetCharacter("InputMove", v).y) * GetCharacter("SpeedMove",0) * deltaTime);

            if (GetCharacter("AttackState",true) == true)
            {
                UpdateCharacter("AccelerateMove", v);
            }

            if (GetCharacter("AttackState", true) == false && GetCharacter("DeathState", true) == false)
            {
                if (GetCharacter("AccelerateMove", v) != v)
                {
                    UpdateCharacter("AnimState", "isRun");
                    UpdateCharacter("SpeedAnim", 1);
                    KeyValuePair<string, IModel> p = new KeyValuePair<string, IModel>("animator", new ModelAnimator { _nameModel = "isRun" });
                    notify(p);
                }
                else if (GetCharacter("AccelerateMove", v) == v)
                {
                    UpdateCharacter("AnimState", "isIdle");
                    UpdateCharacter("SpeedAnim", 1);
                    KeyValuePair<string, IModel> p = new KeyValuePair<string, IModel>("animator", new ModelAnimator { _nameModel = "isIdle" });
                    notify(p);
                }
            }
        }
        public void Rotate(float deltaTime)
        {
            Vector3 v = new Vector3(0,0,0);

            UpdateCharacter("AccelerateRoteY", GetCharacter("AngleEuler", v).y + GetCharacter("InputRotate", v).y * GetCharacter("SpeedRotate", 0) * deltaTime);
            UpdateCharacter("AngleEuler", new Vector3(GetCharacter("InputRotate", v).x, GetCharacter("AccelerateRoteY",0), 0));
        }

        //////////////////////////////////////////////
        public void Attack(string nameAttack)
        {
            UpdateCharacter("AttackState", true);
            UpdateCharacter("AnimState", nameAttack);
            UpdateCharacter("SpeedAnim", GetCharacter("SpeedWeapon", 0));

            KeyValuePair<string, IModel> p = new KeyValuePair<string, IModel>("animator", new ModelAnimator { _nameModel = "isAttack1" });
            notify(p);
        }
        public void AttackDisActive()
        {
            UpdateCharacter("AttackState", false);
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
        public int AddWeapon(IModel mw)
        {
            UpdateCharacter("NameWeapon", mw._nameModel);
            UpdateCharacter("PWeaponDamage", ((ModelWeapon)mw)._pDamage);
            UpdateCharacter("MWeaponDamage", ((ModelWeapon)mw)._mDamage);
            UpdateCharacter("SpeedWeapon", ((ModelWeapon)mw)._speedWeapon);

            if (((ModelWeapon)mw)._countSlot == 1)
            {
                TakeSlot("RightHand", (ISlot)mw);
            }
            if (((ModelWeapon)mw)._countSlot == 2)
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
            //if (_mp._countFrame < 50) { _mp._speedMove = 6; }
            //if (_mp._countFrame > 50) { _mp._speedMove = 2; }
            UpdateCharacter("InputMove", inputMove);
        }
        public void InputRotate(Vector2 inputRotate)
        {
            //if (_mp._countFrame < 50) { _mp._speedRotate = 3; }
            //if (_mp._countFrame > 50) { _mp._speedRotate = 1; }
            UpdateCharacter("InputRotate", inputRotate);
        }

        public float DefineDamage() 
        {
            if(GetCharacter("MWeaponDamage",0) > 0)
                return GetCharacter("MWeaponDamage", 0);
            if (GetCharacter("PWeaponDamage",0) > 0)
                return GetCharacter("PWeaponDamage", 0);
            return 0;
        }

        ////////////////////////////////////////////////
        public void TakeDamage(float hitDamage)
        {
            UpdateCharacter("TakeDamage", hitDamage - GetCharacter("PDefence", 0));
            UpdateCharacter("Health", GetCharacter("Health", 0) - GetCharacter("TakeDamage", 0));
            if (GetCharacter("Health", 0) <= 0) { UpdateCharacter("DeathState", true); UpdateCharacter("Health", 0); }
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

            Vector3 corSpawn = new Vector3(posX, GetCharacter("HSpawn",0), posZ);
            UpdateCharacter("Position", corSpawn);

            return corSpawn;
        }
    }
}
