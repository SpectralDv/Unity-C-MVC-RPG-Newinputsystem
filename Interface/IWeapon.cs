using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Slot;
namespace Weapon
{

    public interface IWeapon : ISlot, IModel
    {

    }
    public interface IWeaponOneHand : IWeapon
    {

    }
    public interface IWeaponTwoHand : IWeapon
    {

    }




    
}