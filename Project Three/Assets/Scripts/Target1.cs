using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target1 : MonoBehaviour
{
    public bool isOpened = false;

    public GameObject gate;

    private void OnTriggerEnter(Collider col)
    {
        if(isOpened == false)
        {
            isOpened = true;
            gate.transform.position += new Vector3 (0f, 7.45f, 0f);
        }
    }
}
