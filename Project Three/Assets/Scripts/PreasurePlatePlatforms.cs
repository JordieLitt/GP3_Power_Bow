using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlatePlatforms : MonoBehaviour
{
    public GameObject platforms;
    public bool steppedOnOne = false;
    public bool steppedOnTwo = false;
    

    bool isDown = false;

    void Start()
    {
        platforms.SetActive(false);
    }
    
    void OnTriggerEnter(Collider col)
    {
        

        if(!steppedOnOne)
        {
            steppedOnOne = true;
        }

        if( steppedOnOne == true && steppedOnTwo == true)
        {
            if(!isDown)
            {
                platforms.SetActive(true);
                isDown = true;
            }
        }
    }

    void OnTriggerEnter(SphereCollider col1)
    {
        if(!steppedOnTwo)
        {
            steppedOnTwo = true;
        }
    }
}
