using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.NullObject
{
    [RequireComponent(typeof(CharacterStats))]
    public class PlayerActions : MonoBehaviour
    {
        CharacterStats _stats = null;

        private void Awake()
        {
            _stats = GetComponent<CharacterStats>();
        }

        public void Attack()
        {
            // if our weapon slot really is a weapon, use it to attack
            // we're using casting here which is a bit messy, but makes for an easy example
            // we have to cast because we know WeaponSlot is IEquippable, but we don't know if it's an IWeapon yet
            IWeapon weaponToUse = _stats.WeaponSlot as IWeapon;
            if (weaponToUse != null)
            {
                weaponToUse.Attack();
            }
        }
    }
}

