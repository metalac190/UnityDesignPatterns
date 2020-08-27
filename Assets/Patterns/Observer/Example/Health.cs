using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Examples.Observer
{
    public class Health : MonoBehaviour
    {
        public event Action<int> Damaged = delegate { };
        public event Action<int> Healed = delegate { };
        public event Action Killed = delegate { };

        [SerializeField] int _startingHealth = 100;
        public int StartingHealth => _startingHealth;

        [SerializeField] int _maxHealth = 100;
        public int MaxHealth => _maxHealth;

        int _currentHealth;
        public int CurrentHealth
        {
            get => _currentHealth;
            set
            {
                // ensure we can't go above our max health
                if(value > _maxHealth)
                {
                    value = _maxHealth;
                }
                _currentHealth = value;
            }
        }

        private void Awake()
        {
            CurrentHealth = _startingHealth;
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
            Healed.Invoke(amount);
        }

        public void TakeDamage(int amount)
        {
            CurrentHealth -= amount;
            Damaged.Invoke(amount);

            if(CurrentHealth <= 0)
            {
                Kill();
            }
        }

        public void Kill()
        {
            Killed.Invoke();
            gameObject.SetActive(false);
        }
    }
}

