using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Observer;
namespace TakeDamage
{
    enum eViewTakeDamage
    {
        ViewPersonage,
        ViewEnemy,
        ViewBoss
    }


    public class ControllerTakeDamage
    {
        private List<ModelTakeDamage> _listView;
        private List<IObserver> _observers;

        public ControllerTakeDamage()
        {
            _listView = new List<ModelTakeDamage>();
            _observers = new List<IObserver>();

            foreach (var i in Enum.GetValues(typeof(eViewTakeDamage)))
            {
                _listView.Add(new ModelTakeDamage { _nameModel = i.ToString() });
            }
        }

        public string FindViewTakeDamage(string nameView)
        {
            string nameModel = _listView.Find(x => x._nameModel.Contains(nameView))._nameModel;

            if (nameModel == nameView) { return nameModel; }
            else{ return "empty"; }
        }

        public void TakeDamage()
        {

        }
    }
}
