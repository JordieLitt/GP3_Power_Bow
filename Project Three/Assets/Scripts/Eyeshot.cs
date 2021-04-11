using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyeshot : MonoBehaviour
{
    public GameObject cyclops;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Arrow2")
        {
            Destroy(cyclops);
        }
    }
}
