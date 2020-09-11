using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines an implementation of our abstract base class to use with
/// our Strategy Pattern inheritance example. The Blast spawns a projectile,
/// triggers a particle, and plays a sound effect.
/// </summary>

namespace Examples.Strategy
{
    public class Blaster : WeaponBase
    {
        public override void Shoot()
        {
            //TODO use Object Pooling for optimization
            //TODO use Template Method to put default shoot in baseclass
            Debug.Log("Shoot the Blaster - Bang!");
            // spawn projectile
            Projectile newProjectile = Instantiate
                (Projectile, ProjectileSpawnLocation.position,
                ProjectileSpawnLocation.rotation);

            // play particles
            ParticleSystem burstParticle = Instantiate
                (ShootParticle, ProjectileSpawnLocation.position,
                Quaternion.identity);
            burstParticle.Play();

            // play audio
            AudioSource.PlayClipAtPoint(ShootSound, ProjectileSpawnLocation.position);
        }
    }
}

