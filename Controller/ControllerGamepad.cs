using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model.MoveRote;
using Model.Gamepad;
namespace Controller.Gamepad
{
    enum eGamepad
    {
        LeftStick,
        RightStick,
        RightStickHor,
        RightStickVer,
        DPadUp,
        DPadDown,
        DPadRight,
        DPadLeft,
        X,
        Y,
        A,
        B,
        L1,
        L2,
        R1,
        R2
    }

    enum MoveRote
    {
        MoveForward,
        MoveBack,
        MoveLeft,
        MoveRight,
        RoteLeft,
        RoteRight,
        RoteUp,
        RoteDown
    };

    public class ControllerGamepad
    {
        List<ModelGamepad> _listGamepad;
        List<ModelMoveRote> _listMoveRote;

        public ControllerGamepad()
        {
            _listGamepad = new List<ModelGamepad>();
            _listMoveRote = new List<ModelMoveRote>();

            foreach (var i in Enum.GetValues(typeof(eGamepad)))
            {
                _listGamepad.Add(new ModelGamepad { _nameModel = i.ToString(), _vectorValue = new Vector2(0, 0), _value = 0 });
            }

            foreach (var i in Enum.GetValues(typeof(MoveRote)))
            {
                _listMoveRote.Add(new ModelMoveRote { _nameModel = i.ToString(), _vectorValue = new Vector2(0, 0), _value = 0 });
            }
        }

        ///////////////////////////////////////////////////////////
        public void AddKey(string nameKey)
        {
            _listGamepad.Add(new ModelGamepad { _nameModel = nameKey, _vectorValue = new Vector2(0, 0), _value = 0 });
        }

        public void UpdateValueKey(string nameKey, Vector2 vectorValue)
        {
            _listGamepad.Find(x => x._nameModel.Contains(nameKey))._vectorValue = vectorValue;
        }
        public Vector2 UpdatePressKey(string nameKey, Vector2 vectorValue)
        {
            return vectorValue;
        }

        ///////////////////////////////////////////////////////////
        public void SetVectorMove(string nameMove, Vector2 vec)
        {
            _listMoveRote.Find(x => x._nameModel.Contains(nameMove))._vectorValue = vec;
        }
        public void SetVectorRotate(string nameRotate, Vector2 vec)
        {
            _listMoveRote.Find(x => x._nameModel.Contains(nameRotate))._vectorValue = vec;
        }

    }
}
