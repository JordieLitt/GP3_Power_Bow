using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTxt : MonoBehaviour
{
     public GameObject message;
     private bool atNPC= false;

    void Start()
    {}

    void Update()
    {
        if(atNPC)
        {
            //display message
            message.SetActive(true);
            //can transition scene
            if(Input.GetKeyDown(KeyCode.E))
            {
            message.SetActive(false);
            }
        }
        else
        {
            //close message
            message.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
          atNPC = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
          atNPC = false;
        }
    }
}
