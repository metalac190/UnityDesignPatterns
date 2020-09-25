using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an example of a possible item that the player can equip... but it's
/// also a weapon! Because it's both we need to implement both interfaces.
/// </summary>

namespace Examples.NullObject
{
    public class SwordOfSwinging : IWeapon, IEquippable
    {
        int _attackPower = 5;
        CharacterStats _stats;

        public SwordOfSwinging(CharacterStats stats)
        {
            _stats = stats;
        }

        public void Attack()
        {
            Debug.Log("Swing and deal " + _stats.Attack + " damage!");
        }

        public void Equip()
        {
            Debug.Log("Equipped Sword of Swinging");
            // add our weapon power to our stats
            _stats.Attack += _attackPower;
        }

        public void Unequip()
        {
            Debug.Log("Unequipped Sword of Swinging");
            // make sure to revert our stats on unequip
            _stats.Attack -= _attackPower;
        }
    }
}

