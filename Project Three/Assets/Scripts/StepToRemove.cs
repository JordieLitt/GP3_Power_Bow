using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepToRemove : MonoBehaviour
{
    public GameObject platforms;

    public bool isSteppedOn = false;

    // Start is called before the first frame update
    void Start()
    {
        platforms.SetActive(true);
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
            platforms.SetActive(false);
        }
    }
}
