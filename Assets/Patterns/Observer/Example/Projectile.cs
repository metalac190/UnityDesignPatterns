using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Observer
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float _travelSpeed = 5f;
        [SerializeField] int _damage = 20;

        Rigidbody _rb = null;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Travel(_rb);
        }

        protected void Travel(Rigidbody rb)
        {
            Vector3 moveOffset = transform.forward * _travelSpeed;
            rb.MovePosition(rb.position + moveOffset);
        }

        private void OnCollisionEnter(Collision other)
        {
            Health health = other.gameObject.GetComponent<Health>();
            health?.TakeDamage(_damage);
            //TODO consider Object Pooling here!
            Destroy(gameObject);
        }
    }
}

