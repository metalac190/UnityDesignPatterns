using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This interface makes sure that any object that is Equippable calls Equip() and Unequip().
/// This is important for adjusting stats when equipped, and undoing the stat adjustments on Unequip().
/// </summary>
namespace Examples.NullObject
{
    public interface IEquippable
    {
        void Equip();
        void Unequip();
    }
}

