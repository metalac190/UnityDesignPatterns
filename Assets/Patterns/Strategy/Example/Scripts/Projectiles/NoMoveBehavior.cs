using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements a new movement behavior that can be used with our
/// Strategy Pattern example on the Projectile - Bonus NullObject Pattern!
/// </summary>

namespace Examples.Strategy
{
    public class NoMoveBehavior : IMoveable
    {
        Rigidbody _rb;

        public NoMoveBehavior(Rigidbody rb)
        {
            _rb = rb;
            // kill current velocity
            _rb.velocity = Vector3.zero;
        }

        public void Move()
        {
            // no movement! This is basically the NullObject Pattern
        }
    }
}
