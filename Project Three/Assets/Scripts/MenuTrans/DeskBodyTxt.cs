using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskBodyTxt : MonoBehaviour
{
   public GameObject message;
    public GameObject messOne;
    public GameObject messTwo;
    public GameObject messThree;
    public GameObject messFour;
    public GameObject messFive;
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
            
            
            if(CrystalChecker.instance.crystals == 0)
            {
                if(Input.GetKeyDown(KeyCode.E) && !messOne.activeInHierarchy)
                {
                messOne.SetActive(true);
               
                }
                else if(Input.GetKeyDown(KeyCode.E) && messOne.activeInHierarchy)
                {
                 messOne.SetActive(false);
                }
            }
            if(CrystalChecker.instance.crystals == 1)
            {
                if(Input.GetKeyDown(KeyCode.E) && !messTwo.activeInHierarchy)
                {
                messTwo.SetActive(true);
                
                }
                else if(Input.GetKeyDown(KeyCode.E) && messTwo.activeInHierarchy)
                {
                 messTwo.SetActive(false);
                }
            }
             if(CrystalChecker.instance.crystals == 2)
            {
                if(Input.GetKeyDown(KeyCode.E) && !messThree.activeInHierarchy)
                {
                messThree.SetActive(true);
               
                }
                else if(Input.GetKeyDown(KeyCode.E) && messThree.activeInHierarchy)
                {
                 messThree.SetActive(false);
                }
            }
            if(CrystalChecker.instance.crystals == 3)
            {
                if(Input.GetKeyDown(KeyCode.E) && !messFour.activeInHierarchy)
                {
                messFour.SetActive(true);
                
                }
                else if(Input.GetKeyDown(KeyCode.E) && messFour.activeInHierarchy)
                {
                 messFour.SetActive(false);
                }
            } 
            if(CrystalChecker.instance.crystals == 4)
            {
                if(Input.GetKeyDown(KeyCode.E) && !messFive.activeInHierarchy)
                {
                messFive.SetActive(true);
               
                }
                else if(Input.GetKeyDown(KeyCode.E) && messFive.activeInHierarchy)
                {
                 messFive.SetActive(false);
                }
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
        messOne.SetActive(false);
        messTwo.SetActive(false);
        messThree.SetActive(false);
        messFour.SetActive(false);
        messFive.SetActive(false);
    }
}
