using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakNormal : MonoBehaviour
{
    public GameObject message;
    public GameObject conversation;
    public bool atNPC= false;
    

    void Update()
    {
        Conversation();
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
          ConversationFalse();
        }
    }

    void Conversation()
    {
        if(atNPC)
        {
            message.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E) && !conversation.activeInHierarchy)
            {

            //enter conversation
            conversation.SetActive(true);
                
            }
            else if(Input.GetKeyDown(KeyCode.E) && conversation.activeInHierarchy)
            {
                conversation.SetActive(false);
            } 
        }
        else
        {
            //close message
            message.SetActive(false);
        }
    }

    void ConversationFalse()
    {
        conversation.SetActive(false);
    }
}
