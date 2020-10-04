using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a simple Health class that we will attach to the Player. Because it's generic, we can actually
/// give anything that we attach to 'Health'. We'll use this so that we can check whether an object has health
/// by searching for this script.
/// </summary>
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

