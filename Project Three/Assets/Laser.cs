using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private LineRenderer lineRend;
    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
    }

    void Update()
    {
        lineRend.SetPosition(0, transform.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider)
            {
                 lineRend.SetPosition(1,hit.point);
            }
        }
        else
        {
            lineRend.SetPosition(1, transform.forward*6000);
        }
    }
}
