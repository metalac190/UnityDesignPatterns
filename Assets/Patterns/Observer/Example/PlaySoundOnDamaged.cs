using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script uses the observer pattern to play sound effects
/// whenever the observed health takes damage or is killed.
/// Note that this script doesn't know about any other scripts
/// or Observers other than the Health, our Subject.
/// </summary>
namespace Examples.Observer
{
    [RequireComponent(typeof(Health))]
    public class PlaySoundOnDamaged : MonoBehaviour
    {
        [SerializeField] AudioClip _damagedSound = null;
        [SerializeField] AudioClip _killedSound = null;
        [SerializeField] Transform _locationToPlay = null;

        Health _health = null;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void OnEnable()
        {
            _health.Damaged += OnDamaged;
            _health.Killed += OnKilled;
        }

        private void OnDisable()
        {
            _health.Damaged -= OnDamaged;
            _health.Killed -= OnKilled;
        }

        void OnDamaged(int damage)
        {
            if(_damagedSound != null && _locationToPlay != null)
            {
                AudioSource.PlayClipAtPoint
                    (_damagedSound, _locationToPlay.position);
            }
        }

        void OnKilled()
        {
            if (_damagedSound != null && _locationToPlay != null)
            {
                AudioSource.PlayClipAtPoint
                    (_killedSound, _locationToPlay.position);
            }
        }
    }
}

