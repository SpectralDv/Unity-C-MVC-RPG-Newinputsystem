using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
namespace SpaceAnimator
{

    public class ModelAnimator : IAnimator
    {
        public string _nameModel { get; set; }
        public string _nameAnim { get; set; }
        public string _strState { get; set; }
        public float _speedAnim { get; set; }
    }

}
