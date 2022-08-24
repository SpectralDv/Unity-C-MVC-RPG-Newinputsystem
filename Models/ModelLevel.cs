using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Model.Level
{
    public class ModelLevel : IModel
    {
        public string _nameModel { get; set; }
        public float _numLevel { get; set; }
        public float _needExpLevel { get; set; }
    }
}

