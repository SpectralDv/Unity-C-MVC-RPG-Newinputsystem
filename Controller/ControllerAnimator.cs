using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//получает данные от контроллера персонажа в метод ChangeAnimState

using Model;
using Observer;
using Model.uAnimator;
namespace Controller.uAnimator
{
    enum AnimState
    {
        isIdle,
        isRun, 
        isWalk, 
        isAttack1, 
        isDeath
    }

    public class ControllerAnimator : IObserverAnimator
    {
        private List<ModelAnimator> _listAnimState;
        private List<IObserverAnimator> _observers;

        public ControllerAnimator()
        {
            _listAnimState = new List<ModelAnimator>();

            foreach (var i in Enum.GetValues(typeof(AnimState)))
            {
                if (i.ToString() == "isIdle")
                {
                    _listAnimState.Add(new ModelAnimator { _nameModel = i.ToString(), _strState = "true", _speedAnim = 1 });
                }
                else
                {
                    _listAnimState.Add(new ModelAnimator { _nameModel = i.ToString(), _strState = "false", _speedAnim = 1 });
                }
            }
        }

        public int ChangeAnimState(string nameState,float speedAnim)
        {
            foreach (var i in Enum.GetValues(typeof(AnimState)))
            {
                {
                    _listAnimState.ForEach(x => x._speedAnim = 1);
                    _listAnimState.ForEach(x => x._strState = "false");
                }
            }
            _listAnimState.Find(x => x._nameModel.Contains(nameState))._speedAnim = speedAnim;
            _listAnimState.Find(x => x._nameModel.Contains(nameState))._strState = "true";

            return 0;
        }

        public string GetAnimState()
        {
            //Debug.Log(_listAnimState.Find(x => x._strState.Contains("true"))._nameModel);
            return _listAnimState.Find(x => x._strState.Contains("true"))._nameModel;
        }
        public float GetAnimSpeed()
        {
            return _listAnimState.Find(x => x._strState.Contains("true"))._speedAnim;
        }

    }
}
