using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is our movement behavior abstraction that we will use as
/// part of our Composition example for the Strategy Pattern. We will
/// define different movement behaviors for the projectiles and swap them
/// out at runtime.
/// </summary>

namespace Examples.Strategy
{
    public interface IMoveable
    {
        void Move();
    }
}

