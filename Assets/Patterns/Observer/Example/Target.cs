using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Examples.Observer
{
    [RequireComponent(typeof(Health))]
    public class Target : MonoBehaviour
    {
        [SerializeField] Slider _healthSlider = null;

        public Health Health { get; private set; }

        private void Awake()
        {
            Health = GetComponent<Health>();

            _healthSlider.maxValue = Health.MaxHealth;
            _healthSlider.value = Health.StartingHealth;
        }

        private void OnEnable()
        {
            // subscribe to get notified when this health takes damage!
            Health.Damaged += OnTakeDamage;
        }

        private void OnDisable()
        {
            Health.Damaged -= OnTakeDamage;
        }

        void OnTakeDamage(int damage)
        {
            // on damaged, display the new health
            _healthSlider.value = Health.CurrentHealth;
        }
    }
}

