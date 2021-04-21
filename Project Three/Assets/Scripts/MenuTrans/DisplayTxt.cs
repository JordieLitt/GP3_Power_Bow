using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTxt : MonoBehaviour
{
    public GameObject message;
    public GameObject conversation;
    public bool atNPC= false;
    public bool talking= false;
    AudioSource nPCAudioSource;
    public AudioClip nPCVoice;

    void Start()
    {
        nPCAudioSource= GetComponent<AudioSource>();
    }

    void Update()
    {
        ConversationOne();
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
          conversation.SetActive(false);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        nPCAudioSource.PlayOneShot(clip);
    }

    void ConversationOne()
    {
        if(atNPC)
        {
            //display message
            message.SetActive(true);
            
            if(!talking)
            {
                if(Input.GetKeyDown(KeyCode.E) && !conversation.activeInHierarchy)
                {

                //enter conversation
                conversation.SetActive(true);
                PlaySound(nPCVoice);
                
                }
                else if(Input.GetKeyDown(KeyCode.E) && conversation.activeInHierarchy)
                {
                     conversation.SetActive(false);
                }
            }

        }
        else
        {
            //close message
            message.SetActive(false);
        }
    }
}
