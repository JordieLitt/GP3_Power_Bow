using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransToHub : MonoBehaviour
{
     public int targetSceneIndex = 0;
     public GameObject message;
     private bool atDoor= false;

    void Start()
    {}

    void Update()
    {
        if(atDoor)
        {
            //display message
            message.SetActive(true);
            //can transition scene
            if(Input.GetKeyDown(KeyCode.E))
            {
                CrystalChecker.instance.entered = true;
                SceneManager.LoadScene(targetSceneIndex);
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
          atDoor = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
          atDoor = false;
        }
    }
}
