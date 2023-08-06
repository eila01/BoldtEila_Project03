using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow = null;

    Vector3 _objectOffSet;
    private void Awake()
    {
        // create an offset between this position and object's position
        _objectOffSet = this.transform.position - _objectToFollow.position;
    }
    
    private void LateUpdate()
    {
        // apply the offset every frame, to reposition this object
        this.transform.position = _objectToFollow.position + _objectOffSet;
    }
}
