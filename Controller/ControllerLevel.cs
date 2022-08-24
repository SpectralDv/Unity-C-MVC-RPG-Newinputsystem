using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model.Level;
namespace Controller.Level
{
    enum eLevel
    {

    };

    class ControllerLevel
    {
        public List<ModelLevel> _listLevel { get; }
        private int _countLevel { get; set; }

        public ControllerLevel()
        {
            _listLevel = new List<ModelLevel>();
            _countLevel = 100;

            for (int i = 1; i <= _countLevel; i++)
            {
                _listLevel.Add(new ModelLevel { _nameModel = "Level"+i.ToString(), _numLevel = i, _needExpLevel = UpdateExpForNextLevel(i, _countLevel) });
            }
        }

        private float UpdateExpForNextLevel(float numLevel,float kExp)
        {
            float countExp = 0;
            for (int i = 0; i < numLevel; i++) { countExp += i * kExp; }

            return countExp;
        }

        public void CheckLevel(float level, float expLevel)
        {

        }

        public float GetExpForNextLevel(float level)
        {
            return _listLevel.Find(x => x._nameModel.Contains("Level"+ level.ToString()))._needExpLevel;
        }

    };
}
