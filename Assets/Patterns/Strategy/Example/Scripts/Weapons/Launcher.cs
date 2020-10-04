using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines an implementation of our abstract base class to use with
/// our Strategy Pattern inheritance example. The Launcher technically
/// uses a lot of the same Shoot() code from the Blaster, but it can be
/// customized individually if needed with this setup
/// </summary>

namespace Examples.Strategy
{
    public class Launcher : WeaponBase
    {
        public override void Shoot()
        {
            //TODO use Object Pooling for optimization
            //TODO use Template Method to put default shoot in baseclass
            Debug.Log("Shoot Launcher - BOOM!");
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
