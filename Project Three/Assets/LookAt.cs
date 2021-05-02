using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    Ray ray;
    RaycastHit hit;
    public float smoothSpeed = .05f;
    
    void LateUpdate()
    {
        LookAtPlayer();     
    }

    void LookAtPlayer()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
