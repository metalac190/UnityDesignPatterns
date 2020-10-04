using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a utility class that just adds visual interest to the pickups, to draw the player's
/// attention to them.
/// </summary>
namespace Examples.TemplateMethod
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] Vector3 _rotationAngle = new Vector3(1, 1, 1);
        [SerializeField] float _rotateSpeed = 1f;

        private void Update()
        {
            //TODO do this with Rigidbody, not transform
            transform.Rotate(_rotationAngle * _rotateSpeed);
        }
    }
}

