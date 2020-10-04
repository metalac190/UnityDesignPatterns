using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is one of our implemented movement behaviors that we will apply to
/// show off our composition example of the Strategy Pattern. We will apply
/// this as one of several possible movement behaviors on the projectile.
/// </summary>

namespace Examples.Strategy
{
    public class LinearMoveBehavior : IMoveable
    {
        float _travelSpeed;
        Rigidbody _rb = null;
        Transform _objectTransform = null;

        public LinearMoveBehavior(Rigidbody rb, float travelSpeed)
        {
            _rb = rb;
            _travelSpeed = travelSpeed;
            _objectTransform = _rb.transform;
        }

        public void Move()
        {
            _rb.velocity = _objectTransform.forward * _travelSpeed;
        }
    }
}

