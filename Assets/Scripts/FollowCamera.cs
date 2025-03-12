using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    
    public Vector3 offset;
    public Transform target;
    float smoothSpeed = 0.0125f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 dir = offset + target.position;

        Vector3 smoothspeed = Vector3.Lerp(transform.position, dir, smoothSpeed);   
        transform.position = smoothspeed;

        transform.LookAt(target.position);
    }
}
