using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstPickupMessage : MonoBehaviour
{

    public GameObject tutorialMessage;
    public float delay = 5f;
    private bool isActive = false;

    void Start()
    {
    }

    void Update()
    {
        if(isActive)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                Destroy(tutorialMessage);
            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            isActive = false;
           Destroy(this);
        }
        
    }

    public void OnDestroy()
    {
        tutorialMessage.SetActive(true);

        Destroy(tutorialMessage, delay);
    }
}
