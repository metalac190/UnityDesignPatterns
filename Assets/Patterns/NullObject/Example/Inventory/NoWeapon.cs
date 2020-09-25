using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is an example of the Null Object Pattern applied to our IWeapon interface
/// Note that nothing happens, but since we're performing a major character action, we're
/// leaving a debug.log statement just to make it really clear
/// </summary>

namespace Examples.NullObject
{
    public class NoWeapon : IWeapon
    {
        public void Attack()
        {
            // nothing happens
            Debug.Log("Can't attack, no weapon available");
        }
    }
}

