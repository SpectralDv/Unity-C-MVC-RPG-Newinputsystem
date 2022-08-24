using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using uAnimator;
namespace Model.uAnimator
{

    public class ModelAnimator : IAnimator
    {
        public string _nameModel { get; set; }
        public string _nameAnim { get; set; }
        public string _strState { get; set; }
        public float _speedAnim { get; set; }
    }

}
