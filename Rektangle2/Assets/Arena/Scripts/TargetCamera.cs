using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCamera : MonoBehaviour
{
    public GameObject Target;
    private Transform _targetTransform;
    private Vector3 cameraOffset;
    
    void Start()
    {
        _targetTransform = Target.transform;
        cameraOffset = new Vector3(0, 10, 0);
    }
    
    void Update()
    {
        this.transform.position = _targetTransform.position + cameraOffset;

    }
}
