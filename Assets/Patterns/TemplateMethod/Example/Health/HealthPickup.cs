using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilize Template Method to hook into OnPickup - easy extension and variability!
/// In this case we're checking to see if the Player also has a Health component attached, and
/// if it does we can add health. This is a handy way of checking for if the object entered has
/// behavior that you can respond to.
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

