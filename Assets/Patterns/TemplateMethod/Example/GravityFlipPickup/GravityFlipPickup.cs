using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This example shows how we can easily add a pickup that can adjust rigidbody physics.
/// As long as we have the Player class, we can check for other components that are attached
/// to the same object as the Player, using GetComponent.
/// </summary>
namespace Examples.TemplateMethod 
{
    public class GravityFlipPickup : Pickup
    {
        protected override void OnPickup(Player player)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if(rb != null)
            {
                // toggle gravity
                Physics.gravity = Physics.gravity * -1;
            }
        }
    }
}


