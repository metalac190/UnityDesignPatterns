using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.ObjectPool
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(AudioSource))]
    public class PlayerTurret : MonoBehaviour
    {
        [SerializeField] Transform _projectileSpawnPoint;
        [SerializeField] Projectile _projectile = null;
        [SerializeField] ProjectilePool _projectilePool = null;
        [SerializeField] float _turnSpeed = 1;

        [Header("Feedback")]
        [SerializeField] ParticleSystem _shootParticles = null;
        [SerializeField] AudioClip _shootSound = null;

        AudioSource _audioSource = null;
        Rigidbody _rb = null;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            // SPACE pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        void FixedUpdate()
        {
            RotateFromInput();
        }

        private void RotateFromInput()
        {
            // calculate amount from input
            float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
            // calculate new rotation
            Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
            // rotate
            _rb.MoveRotation(_rb.rotation * turnOffset);
        }

        public void Fire()
        {
            // fire projectile
            if (_projectile != null)
            {
                // NOT this
                // Projectile newProjectile = Instantiate(_projectile, _projectileSpawnPoint.position, transform.rotation);

                // THIS! Gets a projectile from pool and turns it on
                Projectile newProjectile = _projectilePool.ActivateFromPool();
                // give it the Pool so it can return itself whenever it needs
                newProjectile.AssignPool(_projectilePool);
                // move it to the position we want and enable
                newProjectile.transform.position = _projectileSpawnPoint.transform.position;
                newProjectile.transform.rotation = _projectileSpawnPoint.transform.rotation;
                newProjectile.gameObject.SetActive(true);
            }
            PlayShootFeedback();
        }

        void PlayShootFeedback()
        {
            if (_shootSound != null)
            {
                _audioSource.clip = _shootSound;
                // randomize pitch slightly
                _audioSource.pitch = Random.Range(.9f, 1.1f);
                _audioSource.Play();
            }

            _shootParticles?.Play();
        }
    }
}

