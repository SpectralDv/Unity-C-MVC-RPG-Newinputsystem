using System;
using System.Collections.Generic;
using UnityEngine;


using Model;
namespace Model.Character
{

    public class ModelCharacter : IModel
    {
        public string _nameModel { get; set; }
        public float _value { get; set; }
        public string _string { get; set; }
        public Vector3 _vector { get; set; }
        public bool _event { get; set; }
    }

}
