using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an example of a possible item we could equip on the player.
/// Notice that we can customize different types of modifications to the stats
/// in different items
/// </summary>

namespace Examples.NullObject
{
    public class FeatheryHat : IEquippable
    {
        int _defense = 3;
        int _moveBonus = 1;

        CharacterStats _stats;

        public FeatheryHat(CharacterStats stats)
        {
            _stats = stats;
        }

        public void Equip()
        {
            Debug.Log("Equipped FeatheryHat");
            _stats.Defense += _defense;
            _stats.MoveSpeed += _moveBonus;
        }

        public void Unequip()
        {
            Debug.Log("Unequipped FeatherHat");
            _stats.Defense -= _defense;
            _stats.MoveSpeed -= _moveBonus;
        }
    }
}

