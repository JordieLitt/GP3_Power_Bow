using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealOnCleanse : MonoBehaviour
{
    public int expectedCount;
    public GameObject crystalLights;
    public bool countReached = false;
    
    void Update()
    {
        if(CrystalChecker.instance.crystals == expectedCount)
            {
                crystalLights.GetComponent<Light>().enabled = true;
                countReached = true;
            }
    }
}
