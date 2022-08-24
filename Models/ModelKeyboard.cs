using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
namespace Model.Keyboard
{

    public class ModelKeyboard : IModel
    {
        public string _nameModel { get; set; }
        public bool _eventKey { get; set; }
        public Vector2 _vectorValue { get; set; }
    }

}
