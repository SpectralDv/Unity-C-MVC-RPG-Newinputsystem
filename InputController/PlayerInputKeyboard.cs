using System.Collections;
using System.Collections.Generic;
using System.Linq; //FindObjectsOfType
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


using View.Keyboard;
namespace View
{
    public class PlayerInputKeyboard : MonoBehaviour
    {
        private float numPlayer;
        public PlayerInput playerInput;

        private Vector2 moveVector2;
        private float rotateHorValue;
        private float rotateVertValue;
        private Vector2 rotateVector2;

        private List<Vector2> listMove;
        private List<Vector2> listRote;

        private ViewKeyboard viewKeyboard;


        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            numPlayer = playerInput.playerIndex;

            var viewKeyboards = FindObjectsOfType<ViewKeyboard>();
            viewKeyboard = viewKeyboards.FirstOrDefault(m => m.GetNumPlayer() == numPlayer);
        }

        public float GetNumPlayer()
        {
            return numPlayer;
        }

        ////////////////////////////////////////////
        private void OnKeyW()
        {
            //Debug.Log("KeyW");
            viewKeyboard.InputKeyboardMove("KeyW", "MoveForward", new Vector2(0, 1));
        }
        private void OnKeyS()
        {
            //Debug.Log("KeyS");
            viewKeyboard.InputKeyboardMove("KeyS", "MoveBack", new Vector2(0, -1));
        }
        private void OnKeyA()
        {
            //Debug.Log("KeyA");
            viewKeyboard.InputKeyboardMove("KeyA", "MoveLeft", new Vector2(-1, 0));
        }
        private void OnKeyD()
        {
            //Debug.Log("KeyD");
            viewKeyboard.InputKeyboardMove("KeyD", "MoveRight", new Vector2(1, 0));
        }

        /////////////////////////////////////////////////////
        private void OnKeyI()
        {
            //Debug.Log("KeyI");
            viewKeyboard.InputKeyboardRotate("KeyI", "RoteUp", new Vector2(-1, 0));
        }
        private void OnKeyK()
        {
            //Debug.Log("KeyK");
            viewKeyboard.InputKeyboardRotate("KeyK", "RoteDown", new Vector2(1, 0));
        }
        private void OnKeyJ()
        {
            //Debug.Log("KeyJ");
            viewKeyboard.InputKeyboardRotate("KeyJ", "RoteLeft", new Vector2(0, -1));
        }
        private void OnKeyL()
        {
            //Debug.Log("KeyL");
            viewKeyboard.InputKeyboardRotate("KeyL", "RoteRight", new Vector2(0, 1));
        }

        /////////////////////////////////////////////////////
        private void OnKeySpace()
        {
            Debug.Log("KeySpace");
            viewKeyboard.InputKeyboardAttack("KeySpace", "Attack1");
        }
    }
}
