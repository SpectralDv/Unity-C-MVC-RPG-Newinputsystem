using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
namespace Gamepad
{

    public class ModelGamepad : IModel
    {
        public string _nameModel { get; set; }
        public Vector2 _vectorValue { get; set; }
        public float _value { get; set; }
    }

}