using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPressure : MonoBehaviour
{
    public GameObject platforms;

    public bool astraOn = false;
   
    // Start is called before the first frame update
    void Start()
    {
        platforms.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            astraOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(astraOn == true)
        {
            platforms.SetActive(true);
        }
    }
}
