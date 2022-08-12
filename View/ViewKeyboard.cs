using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


using Keyboard;
namespace View
{

    public class ViewKeyboard : MonoBehaviour
    {
        public float playerIndex;

        public ControllerKeyboard controllerKeyboard;

        private ViewPlayer viewPlayer;
        private ViewPersonage viewPersonage;

        void Awake()
        {
            viewPlayer = transform.GetComponent<ViewPlayer>();
            viewPersonage = transform.GetComponent<ViewPersonage>();
        }

        public ViewKeyboard()
        {
            controllerKeyboard = new ControllerKeyboard();
        }

        public float GetPlayerIndex()
        {
            return playerIndex;
        }

        public void InputKeyboardMove(string nameKey, string nameMove, Vector2 vectorKey)
        {
            Vector2 moveVector = controllerKeyboard.UpdatePressKey(nameKey, vectorKey);
            controllerKeyboard.SetVectorMove(nameMove, moveVector);

            viewPlayer.InputVectorMove(controllerKeyboard.GetVectorMove());
        }
        public void InputKeyboardRotate(string nameKey, string nameRotate, Vector2 vectorKey)
        {
            Vector2 roteVector = controllerKeyboard.UpdatePressKey(nameKey, vectorKey);
            controllerKeyboard.SetVectorRotate(nameRotate, roteVector);

            viewPlayer.InputVectorRotate(controllerKeyboard.GetVectorRotate());
        }
        public void InputKeyboardAttack(string nameKey,string nameAttack)
        {
            viewPersonage.InputAttack(nameAttack);
        }
    }

}
