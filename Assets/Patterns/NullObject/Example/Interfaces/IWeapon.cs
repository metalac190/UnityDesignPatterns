using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This interface just ensures that all weapons define something to happen when Attack() is called
/// </summary>
namespace Examples.NullObject
{
    public interface IWeapon
    {
        void Attack();
    }
}

