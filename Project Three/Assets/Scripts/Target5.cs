﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target5 : MonoBehaviour
{
   public bool isOpened = false;

    public GameObject gate;

    public GameObject symbol;

    private void OnTriggerEnter(Collider col)
    {
        if(isOpened == false)
        {
            isOpened = true;
            gate.transform.position += new Vector3 (0f, 1.6f, 0f);
            Destroy(symbol.gameObject);
        }
    }
}
