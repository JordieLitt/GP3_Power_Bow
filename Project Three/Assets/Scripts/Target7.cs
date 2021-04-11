using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target7 : MonoBehaviour
{
    public bool isOpened = false;

    public GameObject gate;

    public GameObject symbol;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Arrow2")
        {
            isOpened = true;
            gate.transform.position += new Vector3 (0f, 7.45f, 0f);
            Destroy(symbol);
        }
    }
}
