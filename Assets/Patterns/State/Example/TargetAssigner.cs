using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TargetAssigner : MonoBehaviour
{
    public event Action<Vector3> NewTargetAcquired = delegate { };

    Camera _camera = null;
    RaycastHit _hitInfo;

    private void Awake()
    {
        _camera = Camera.main;
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

        if(Physics.Raycast(ray, out _hitInfo, Mathf.Infinity))
        {
            Debug.Log("Ray hit: " + _hitInfo.transform.name 
                + " at coordinates: " + _hitInfo.point);
        }
    }

    public void SetNewTargetPoint(Vector3 position)
    {
        NewTargetAcquired.Invoke(position);
    }
}
