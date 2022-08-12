using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Gamepad;
namespace View
{

    public class ViewGamepad : MonoBehaviour
    {
        public float playerIndex;

        private ControllerGamepad controllerGamepad;

        private ViewPersonage viewPersonage;
        private ViewPlayer viewPlayer;

        void Awake()
        {
            viewPersonage = transform.GetComponent<ViewPersonage>();
            viewPlayer = transform.GetComponent<ViewPlayer>();
        }

        public ViewGamepad()
        {
            controllerGamepad = new ControllerGamepad();
        }

        public float GetPlayerIndex() {  return playerIndex; }

        public void InputGamepadMove(string nameKey, Vector2 vectorValue)
        {
            Vector2 vec = new Vector2();
            vec = controllerGamepad.UpdatePressKey(nameKey, vectorValue);
            viewPlayer.InputVectorMove(vec);
        }
        public void InputGamepadRotate(string nameKey, Vector2 vectorValue)
        {
            Vector2 vec = new Vector2();
            vec = controllerGamepad.UpdatePressKey(nameKey, vectorValue);
            viewPlayer.InputVectorRotate(vec);
        }

        public void InputGamepadAttack(string nameKey, string nameAttack)
        {
            viewPersonage.InputAttack(nameAttack);
        }


    }

}
