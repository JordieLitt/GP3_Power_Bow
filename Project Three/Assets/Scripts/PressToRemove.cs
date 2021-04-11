using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToRemove : MonoBehaviour
{
    public GameObject platform;
    public bool isSteppedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        platform.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            isSteppedOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSteppedOn == true)
        {
            platform.SetActive(false);
        }
    }
}
