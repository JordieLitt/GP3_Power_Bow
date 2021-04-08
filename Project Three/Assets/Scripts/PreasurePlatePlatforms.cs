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
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if(steppedOnOne == false)
            {
                steppedOnOne = true;
            }
            else
            {
                steppedOnTwo = true;
            }
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
}
