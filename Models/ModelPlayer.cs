using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
namespace Model.Player
{
    public class ModelPlayer : IModel
    {
        public string _nameModel { get; set; }
        public IModel _modelPersonage { get; set; }
        public IModel _inputSystem { get; set; }
    }

}
