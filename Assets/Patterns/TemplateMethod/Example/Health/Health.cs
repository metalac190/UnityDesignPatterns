using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.TemplateMethod
{
    public class Health : MonoBehaviour
    {
        public int CurrentHealth { get; private set; }

        public void Damage(int amount)
        {
            CurrentHealth -= amount;
            Debug.Log("Damage player +" + amount.ToString());
            if (CurrentHealth <= 0)
            {
                Kill();
            }
        }

        public void Heal(int amount)
        {
            CurrentHealth += amount;
            Debug.Log("Heal player +" + amount.ToString());
        }

        public void Kill()
        {
            gameObject.SetActive(false);
        }
    }
}

