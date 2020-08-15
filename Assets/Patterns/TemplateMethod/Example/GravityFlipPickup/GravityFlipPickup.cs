using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


