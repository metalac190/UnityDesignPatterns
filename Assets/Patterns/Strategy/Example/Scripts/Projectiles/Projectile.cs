using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// In this class we'll look at how to use the Strategy Pattern with Composition/interfaces.
/// The 'move behavior' is our abstracted behavior that we can change at runtime.
/// This means that at any point in time we can change the way the projectile
/// moves, and easily add new movements. Check out the Slow Field to see how
/// we can change the movement behavior of projectiles that pass through it.
/// </summary>

namespace Examples.Strategy
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        // STRATEGY PATTERN - we want to change the projectile's flight pattern
        // at runtime - powerups? levelups? talent trees?
        IMoveable _moveBehavior;

        [SerializeField] float _travelSpeed = 10;
        public float TravelSpeed => _travelSpeed;

        Rigidbody _rb = null;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            // establish our initial projectile movement behavior
            _moveBehavior = new LinearMoveBehavior(_rb, _travelSpeed);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Projectile collision");
            //TODO check for damageable
            //Destroy(gameObject);
        }

        private void FixedUpdate()
        {
            _moveBehavior.Move();
        }

        public void SetMoveBehavior(IMoveable newMoveBehavior)
        {
            Debug.Log("Changing projectile flight behavior!");
            _moveBehavior = newMoveBehavior;
        }
    }
}

