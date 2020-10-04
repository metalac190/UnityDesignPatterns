using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a fairly large class, but encompasses most of the Projectile functionality.
/// Whenever these are 'Destroyed' we check to see if they're associated with a pool. If they are, then
/// they are destroyed.
/// </summary>
namespace Examples.ObjectPool
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float _travelSpeed = 5f;
        [SerializeField] float _lifeTime = 1.5f;

        Rigidbody _rb = null;
        ProjectilePool _projectilePool = null;
        Coroutine _selfDestructRoutine = null;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            if (_selfDestructRoutine != null)
                StopCoroutine(_selfDestructRoutine);
            _selfDestructRoutine = StartCoroutine(DestroyAfterSeconds(_lifeTime));
        }

        private void OnDisable()
        {
            if (_selfDestructRoutine != null)
                StopCoroutine(_selfDestructRoutine);
        }

        // using this as a substitute for Constructor on MB
        public void AssignPool(ProjectilePool projectilePool)
        {
            _projectilePool = projectilePool;
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
            // do damage
            RemoveSelf();
        }

        void RemoveSelf()
        {
            if (_projectilePool != null)
            {
                // return to Pool, instead of Destroy
                _projectilePool.ReturnToPool(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        IEnumerator DestroyAfterSeconds(float lifeTime)
        {
            yield return new WaitForSeconds(lifeTime);
            RemoveSelf();
        }
    }
}


