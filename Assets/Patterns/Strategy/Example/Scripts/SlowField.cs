using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class shows how we can apply the Composition-type of Strategy Pattern.
/// We will apply a new movement behavior to any new projectile that passes through.
/// Feel free to create another type of field we a new custom movement behavior!
/// </summary>

namespace Examples.Strategy
{
    public class SlowField : MonoBehaviour
    {
        [SerializeField] float _accelerateAmount = .2f;

        private void OnTriggerEnter(Collider other)
        {
            Projectile incomingProjectile =
                other.gameObject.GetComponent<Projectile>();
            // if it's a valid projectile, apply a new movement behavior
            if (incomingProjectile != null)
            {
                AccelerateMoveBehavior slowStart = new AccelerateMoveBehavior
                    (other.attachedRigidbody, _accelerateAmount);
                incomingProjectile.SetMoveBehavior(slowStart);
            }
        }
    }
}

