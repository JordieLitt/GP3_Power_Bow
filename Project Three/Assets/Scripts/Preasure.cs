using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preasure : MonoBehaviour
{
    
    public bool steppedOn = false;
    void OnTriggerEnter(Collider col)
    {
        
        if(!steppedOn)
        {
        steppedOn = true;
        }
        
    }
    bool GetBool()
    {
        return steppedOn;
    }
}
