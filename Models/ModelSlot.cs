using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Slot;
namespace Model.Slot
{
    public class ModelSlot : ISlot
    {
        public string _nameModel { get; set; }
        public ISlot _slot { get; set; }
    }
}
