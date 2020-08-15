using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilize Template Method to hook into OnPickup - easy extension and variability!
/// </summary>
namespace Examples.TemplateMethod
{
    public class HealthPickup : Pickup
    {
        [SerializeField] int _healAmount = 20;
        protected override void OnPickup(Player player)
        {
            Health health = player.GetComponent<Health>();
            health?.Heal(_healAmount);
        }
    }
}

