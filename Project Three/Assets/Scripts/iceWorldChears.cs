﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceWorldChears : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            player.transform.position = new Vector3(454, 85, 242);
        }
    }
}
