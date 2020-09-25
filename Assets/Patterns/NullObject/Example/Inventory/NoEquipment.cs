using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an example of the Null Object Pattern for a piece of equipment
/// Notice that nothing happens when we try to equip or unequip it
/// </summary>

namespace Examples.NullObject
{
    public class NoEquipment : IEquippable
    {
        public void Equip()
        {
            // nothing happens
        }

        public void Unequip()
        {
            // nothing happens
        }
    }
}

