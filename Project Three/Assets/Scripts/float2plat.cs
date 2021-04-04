using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class float2plat : MonoBehaviour
{
    public GameObject target;

    void Start()
    {
        target.GetComponent<MeshRenderer>().enabled = false;
    }

     private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            target.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
