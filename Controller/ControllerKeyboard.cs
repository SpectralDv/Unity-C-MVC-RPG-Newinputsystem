using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Player;
namespace Keyboard
{
    enum eKeys
    {
        KeyW,
        KeyS,
        KeyA,
        KeyD,
        KeyI,
        KeyK,
        KeyJ,
        KeyL,
        KeySpace
    };

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


    public class ControllerKeyboard
    {
        private List<ModelKeyboard> _listMKey;
        private List<ModelMoveRote> _listMoveRote;

        public ControllerKeyboard()
        {
            _listMKey = new List<ModelKeyboard>();
            _listMoveRote = new List<ModelMoveRote>();

            foreach (var i in Enum.GetValues(typeof(eKeys)))
            {
                _listMKey.Add(new ModelKeyboard { _nameModel = i.ToString(), _eventKey = false, _vectorValue = new Vector2(0, 0) });
            }

            foreach (var i in Enum.GetValues(typeof(MoveRote)))
            {
                _listMoveRote.Add(new ModelMoveRote { _nameModel = i.ToString(), _vectorValue = new Vector2(0, 0), _value = 0 });
            }
        }

        //////////////////////////////////////////////////////////////
        public void AddKey(string nameKey)
        {
            _listMKey.Add(new ModelKeyboard { _nameModel = nameKey, _eventKey = false, _vectorValue = new Vector2(0, 0) });
        }
        public void UpdateEventKey(string nameKey, bool eventKey)
        {
            _listMKey.Find(x => x._nameModel.Contains(nameKey))._eventKey = eventKey;
        }
        public void UpdateValueKey(string nameKey, Vector2 vectorValue)
        {
            _listMKey.Find(x => x._nameModel.Contains(nameKey))._vectorValue = vectorValue;
        }

        public Vector2 UpdatePressKey(string nameKey, Vector2 vectorValue)
        {
            ModelKeyboard mk = new ModelKeyboard();
            mk = _listMKey.Find(x => x._nameModel.Contains(nameKey));

            if (mk._eventKey == false)
            {
                mk._eventKey = true;
                mk._vectorValue = vectorValue;
            }
            else
            {
                mk._eventKey = false;
                mk._vectorValue = new Vector2(0, 0);
            }
            return mk._vectorValue;
        }

        /////////////////////////////////////////////////////////////
        public Vector2 GetVectorMove()
        {
            float x = _listMoveRote[2]._vectorValue.x + _listMoveRote[3]._vectorValue.x;
            float y = _listMoveRote[0]._vectorValue.y + _listMoveRote[1]._vectorValue.y;

            if ((x == 1f) && (y == 1f)) { x = 0.7f; y = 0.7f; }
            if ((x == -1f) && (y == 1f)) { x = -0.7f; y = 0.7f; }
            if ((x == -1f) && (y == -1f)) { x = -0.7f; y = -0.7f; }
            if ((x == 1f) && (y == -1f)) { x = 0.7f; y = -0.7f; }

            Vector2 moveVector2 = new Vector2(x, y);
            return moveVector2;
        }
        public Vector2 GetVectorRotate()
        {
            float roteY = _listMoveRote[4]._vectorValue.y + _listMoveRote[5]._vectorValue.y;
            float roteX = _listMoveRote[6]._vectorValue.x + _listMoveRote[7]._vectorValue.x;

            if (roteX > 180) { roteX = -360 + roteX; }

            Vector2 roteVector2 = new Vector2(roteX, roteY);

            return roteVector2;
        }
        //////////////////////////////////////////////
        public void SetVectorMove(string name, Vector2 vec)
        {
            _listMoveRote.Find(x => x._nameModel.Contains(name))._vectorValue = vec;
        }
        public void SetVectorRotate(string name, Vector2 vec)
        {
            _listMoveRote.Find(x => x._nameModel.Contains(name))._vectorValue = vec;
        }

    }
}
