using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model.Game;
namespace Controller.Game
{
    public class ControllerGame 
    {
        private ModelGame _mGame;

        public ControllerGame()
        {
            _mGame = new ModelGame();
        }

        public void ChangeCountPlayer(float value)
        {
            _mGame._countPlayer = value;
        }

    }
}
