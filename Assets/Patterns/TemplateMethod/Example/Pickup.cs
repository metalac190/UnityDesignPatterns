using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is our Template Method Object. We can create one kind of pickup, do all
/// of the boilerplate detection, and then expose the method that subclasses
/// should call to change the effect of 'player collision'
/// </summary>
namespace Examples.TemplateMethod
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(AudioSource))]
    public abstract class Pickup : MonoBehaviour
    {
        // this is our template method. Subclasses must implement
        protected abstract void OnPickup(Player player);

        [Header("Feedback")]
        [SerializeField] AudioClip _pickupSFX;
        [SerializeField] ParticleSystem _particlePrefab;

        Collider _collider = null;
        AudioSource _audioSource = null;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _audioSource = GetComponent<AudioSource>();
        }

        // Reset gets called whenever you add a component to an object
        private void Reset()
        {
            // set isTrigger in the Inspector, just in case Designer forgot
            Collider collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            // guard clause
            Player player = other.GetComponent<Player>();
            if (player == null)
                return;

            // found the player! call our abstract method and supporting feedback
            OnPickup(player);

            if (_pickupSFX != null)
            {
                SpawnAudio(_pickupSFX);
            }  

            if (_particlePrefab != null)
            {
                SpawnParticle(_particlePrefab);
            }

            Disable();
        }

        void SpawnAudio(AudioClip pickupSFX)
        {
            AudioSource.PlayClipAtPoint(pickupSFX, transform.position);
        }

        void SpawnParticle(ParticleSystem pickupParticles)
        {
            ParticleSystem newParticles =
                Instantiate(pickupParticles, transform.position, Quaternion.identity);
            newParticles.Play();
        }

        // allow override in case subclass wants to object pool, etc.
        protected virtual void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}

