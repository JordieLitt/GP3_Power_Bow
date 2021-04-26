using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBjMatChange : MonoBehaviour
{
     public Material baseMat, cleanseMat;
    public int expectedCount = 0;
   

    void Start()
    {
        GetComponent<Renderer>().material = baseMat;
    }

    // Update is called once per frame
    void Update()
    {
        if(CrystalChecker.instance != null && CrystalChecker.instance.crystals >= expectedCount)
        {
            GetComponent<Renderer>().material = cleanseMat;
        }
    }
}
