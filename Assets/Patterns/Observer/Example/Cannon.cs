using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples.Observer
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] Projectile _projectile = null;
        [SerializeField] Transform _projectileSpawnPoint = null;

        private void Update()
        {
            // fire zeh missiles
            if (Input.GetKeyDown(KeyCode.Space))
            {
                FireProjectile();
            }
        }

        void FireProjectile()
        {
            Projectile newProjectile = Instantiate(_projectile, 
                _projectileSpawnPoint.position, transform.rotation);
        }
    }
}

