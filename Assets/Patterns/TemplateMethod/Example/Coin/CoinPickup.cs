using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Utilize Template Method to hook into OnPickup - easy extension and variability!
/// Because the method call sends the player, we have everything we need to access public methods
/// and fields on the Player class.
/// </summary>
namespace Examples.TemplateMethod
{
    public class CoinPickup : Pickup
    {
        [SerializeField] int _coinValue = 1;

        protected override void OnPickup(Player player)
        {
            player.AddCoin(_coinValue);
        }
    }
}

