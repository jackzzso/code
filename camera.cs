using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehavior {
    public static CameraFollower instance;

    public float MovementSmoothness = 1f;
    public float RotationSmoothness = 1f;
    public GameObject FollowTarget;
    public bool CanFollow = true;

    void Awake()
    {
        instance = this;
    }
    void Start() 
    {

    }
    void LateUpdate()
    {
        if(FollowTarget == null || !canFollow)
            return;
        transform.position = Vector3.Lerp(transform.position,FollowTarget.transform.position,Time.deltaTIme*MovementSmoothness);
        transform.rotation - Quaternion.Slerp(transform.rotation,FollowTarget.transform.rotation,Time.deltaTime*RotationSmoothness);
    }
}

