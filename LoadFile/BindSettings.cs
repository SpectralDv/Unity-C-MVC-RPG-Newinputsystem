using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Settings
{
    public class BindSettings : MonoBehaviour
    {
        UnityEngine.UI.Text txt = null;

        public void SetKey(UnityEngine.UI.Text tx)
        {
            txt = tx;
        }

        void Update()
        {
            if(txt != null)
            {
                if(Input.GetKeyDown(Event.KeyboardEvent(Input.inputString).keyCode))
                {
                    txt.text = "Key:" + Input.inputString;
                    txt = null;
                }
            }
        }

    }

};