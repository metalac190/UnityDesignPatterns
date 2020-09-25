using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.NullObject
{
    public class CharacterStats : MonoBehaviour
    {
        // assign an empty equipment by default - don't let it be null!
        public IEquippable WeaponSlot { get; set; } = new NoEquipment();
        public IEquippable HelmetSlot { get; set; } = new NoEquipment();

        public int Attack { get; set; } = 0;
        public int Defense { get; set; } = 0;
        public int MoveSpeed { get; set; } = 3;

        // note that we're not enforcing which slots items can be equipped to, just that it's equippable.
        // we can define 'weapon' and 'helmet' further in a base class if we want, but for now I'm
        // keeping the example simple. Currently we can wear a sword as a hat...
        // which to be honest sounds pretty cool.

        public void EquipWeapon(IEquippable weapon)
        {
            // check to see if it is a type of weapon. Note this is a little messy, but keeps the example simple
            if (weapon is IWeapon)
            {
                WeaponSlot.Unequip();
                WeaponSlot = weapon;
                WeaponSlot.Equip();
            }
            else
            {
                Debug.Log("Can only equip weapons");
            }
        }

        public void EquipHelmet(IEquippable helmet)
        {
            HelmetSlot.Unequip();
            HelmetSlot = helmet;
            HelmetSlot.Equip();
        }

        public void UnequipAll()
        {
            WeaponSlot.Unequip();   // ensure this item's Unequip effects happen
            WeaponSlot = new NoEquipment();

            HelmetSlot.Unequip();   // ensure this item's Unequip effets happen
            HelmetSlot = new NoEquipment();
        }
    }
}

