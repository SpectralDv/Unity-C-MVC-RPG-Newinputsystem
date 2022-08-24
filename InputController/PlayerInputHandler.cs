using System.Collections;
using System.Collections.Generic;
using System.Linq; //FindObjectsOfType
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;


using View.Gamepad;
namespace View
{

    public class PlayerInputHandler : MonoBehaviour
    {
        private float numPlayer;
        private PlayerInput playerInput;

        private ViewCamera viewCamera;
        private ViewPlayer viewPlayer;
        private ViewGamepad viewGamepad;

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();
            numPlayer = playerInput.playerIndex;

            var viewPlayers = FindObjectsOfType<ViewPlayer>();
            viewPlayer = viewPlayers.FirstOrDefault(m => m.GetNumPlayer() == numPlayer);

            var viewGamepads = FindObjectsOfType<ViewGamepad>();
            viewGamepad = viewGamepads.FirstOrDefault(m => m.GetNumPlayer() == numPlayer);
        }

        //////////////////////////////////////////
        private void OnLeftStick(InputValue value)
        {
            //Debug.Log("OnLeftStick");
            viewGamepad.InputGamepadMove("LeftStick", value.Get<Vector2>());
        }
        private void OnRightStick(InputValue value)
        {
            //Debug.Log("OnRightStick");
            viewGamepad.InputGamepadRotate("RightStick", value.Get<Vector2>());
        }
        private void OnRightStickHor(InputValue value)
        {
            //Debug.Log("OnRightStickHor");
            viewGamepad.InputGamepadRotate("RightStickHor", new Vector2(0, value.Get<float>()));
        }
        private void OnRightStickVert(InputValue value)
        {
            //Debug.Log("OnRightStickVert");
            viewGamepad.InputGamepadRotate("RightStickVer", new Vector2(value.Get<float>(), 0));
        }
        /////////////////////////////////////
        private void OnX()
        {
            Debug.Log("OnX");
            viewGamepad.InputGamepadAttack("KeySpace", "Attack1");
        }
        private void OnY()
        {
            Debug.Log("OnY");
        }
        private void OnA()
        {
            Debug.Log("OnA");
        }
        private void OnB()
        {
            Debug.Log("OnB");
        }
        ///////////////////////////////////
        private void OnDPAD()
        {
            Debug.Log("OnDPAD");
        }
        /////////////////////////////////////
        private void OnL1()
        {
            Debug.Log("OnL1");
        }
        private void OnL2()
        {
            Debug.Log("OnL2");
        }
        private void OnR1()
        {
            Debug.Log("OnR1");
        }
        private void OnR2()
        {
            Debug.Log("OnR2");
        }
        ////////////////////////////////////
        private void OnStart()
        {
            Debug.Log("OnStart");
        }
        private void OnSelect()
        {
            Debug.Log("OnSelect");
        }
        
    }



}