using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Implements a new movement behavior that can be used with our
/// Strategy Pattern example on the Projectile
/// </summary>

namespace Examples.Strategy
{
    public class AccelerateMoveBehavior : IMoveable
    {
        float _currentSpeed;
        Rigidbody _rb;
        float _accelerateSpeed;
        Transform _objectTransform;

        public AccelerateMoveBehavior(Rigidbody rb, float accelerateSpeed)
        {
            _currentSpeed = 0;
            _rb = rb;
            _accelerateSpeed = accelerateSpeed;
            _objectTransform = _rb.transform;
        }

        public void Move()
        {
            // this assumes we're calling Move in FixedUpdate - kinda hacky
            _currentSpeed += _accelerateSpeed;
            _rb.velocity = _objectTransform.forward * _currentSpeed;
        }
    }
}

