using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// This class handles the targeting system. I'm keeping this as a separate class so that you can
/// clearly see the functionality of the SearchBot State Machine.
/// This class sets a new target on mouse click and sends out a notification that are classes can hook
/// into to get notified when a new target has been set. We're using Observer Pattern and events here,
/// to show how well they work with State Machines.
/// </summary>

namespace Examples.State
{
    [RequireComponent(typeof(AudioSource))]
    public class TargetAssigner : MonoBehaviour
    {
        public event Action<Vector3> NewTargetAcquired = delegate { };

        [SerializeField] AudioClip _newTargetSound;
        [SerializeField] GameObject _targetIndicatorPrefab;
        GameObject _targetIndicator;

        Camera _camera = null;
        RaycastHit _hitInfo;

        private void Awake()
        {
            // get references
            _camera = Camera.main;
            // setup the target indicator visual and hide it
            _targetIndicator = Instantiate(_targetIndicatorPrefab, _hitInfo.point, Quaternion.identity);
            _targetIndicator.SetActive(false);
        }

        void Update()
        {
            // LEFT CLICK - set new target
            if (Input.GetMouseButtonDown(0))
            {
                GetNewMouseHit(_camera);
                SetNewTargetPoint(_hitInfo.point);
            }
        }

        public void GetNewMouseHit(Camera camera)
        {
            // get a ray hit point from camera click location
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
            {
                Debug.Log("Ray hit: " + _hitInfo.transform.name
                    + " at coordinates: " + _hitInfo.point);
            }
        }

        public void SetNewTargetPoint(Vector3 position)
        {
            // handle the target visual
            _targetIndicator.SetActive(true);
            _targetIndicator.transform.position = position;
            // feedback
            AudioSource.PlayClipAtPoint(_newTargetSound, _camera.transform.position);
            // send out notification
            NewTargetAcquired.Invoke(position);
        }
    }
}

