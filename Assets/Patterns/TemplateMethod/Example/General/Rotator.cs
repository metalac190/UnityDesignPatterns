using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

