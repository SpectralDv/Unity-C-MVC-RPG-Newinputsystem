using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Observer;
namespace Weapon 
{
    public class ControllerWeapon : IObservable
    {
        private List<IObserverWeapon> _observers;
        private List<ModelWeapon> _listWeapon;

        public ControllerWeapon()
        {
            _observers = new List<IObserverWeapon>();
            _listWeapon = new List<ModelWeapon>();
            Debug.Log("ControllerWeapon");
        }

        public List<ModelWeapon> GetListWeapon()
        {
            return _listWeapon;
        }

        public void AddListWeapon(string nameWeapon,float pDamage,float mDamage,float countSlot,float speedWeapon)
        {
            _listWeapon.Add(new ModelWeapon 
            { 
                _nameModel = nameWeapon, _pDamage = pDamage, _mDamage = mDamage, _countSlot = countSlot, _speedWeapon = speedWeapon
            });
        }
        public void ClearListWeapon()
        {
            _listWeapon.Clear();
        }
        public ModelWeapon GetModelWeapon(string nameWeapon)
        {
            return (_listWeapon.Find(x => x._nameModel.Contains(nameWeapon)));
        }

        public void FillListWeapon()
        {
            _listWeapon.Add(new ModelWeapon { _nameModel = "OneHandSword", _pDamage = 100, _mDamage = 0, _countSlot = 1, _speedWeapon = 1 });
        }

        public void AddObserver(IObserver o) 
        {
            _observers.Add((IObserverWeapon)o);
        }
        public void RemoveObserver(IObserver io) 
        {
            foreach (IObserverWeapon o in _observers)
            {
                if (io == o) { _observers.Remove(o); break; }
            }
        }
        public void notify(KeyValuePair<string, IModel> p) 
        {
            if (p.Key == "weapon") 
            {
                foreach (IObserverWeapon o in _observers) 
                {
                    int ret = o.AddWeapon((ModelWeapon)p.Value);
                }
            }
        }
    }
}
