using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTxt : MonoBehaviour
{
    public GameObject message;
    public GameObject conversationOne;
    public GameObject conversationTwo;
    public GameObject conversationThree;
    public bool atNPC= false;
    AudioSource nPCAudioSource;
    public AudioClip nPCVoice;
    public int expectedCountOne;
    public int expectedCountTwo;

    void Start()
    {
        nPCAudioSource= GetComponent<AudioSource>();
    }

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

    public void PlaySound(AudioClip clip)
    {
        nPCAudioSource.PlayOneShot(clip);
    }

    void Conversation()
    {
        if(atNPC)
        {
            message.SetActive(true);
            
            
            if(CrystalChecker.instance.crystals < expectedCountOne)
            {
                if(Input.GetKeyDown(KeyCode.E) && !conversationOne.activeInHierarchy)
                {

                //enter conversation
                conversationOne.SetActive(true);
                PlaySound(nPCVoice);
                
                }
                else if(Input.GetKeyDown(KeyCode.E) && conversationOne.activeInHierarchy)
                {
                 conversationOne.SetActive(false);
                }
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.E) && !conversationTwo.activeInHierarchy)
                {
                //enter conversation
                conversationTwo.SetActive(true);
                PlaySound(nPCVoice);
                
                }
                else if(Input.GetKeyDown(KeyCode.E) && conversationTwo.activeInHierarchy)
                {
                 conversationTwo.SetActive(false);
                }
            }
            if(CrystalChecker.instance.crystals >= expectedCountTwo)
            {
                if(Input.GetKeyDown(KeyCode.E) && !conversationThree.activeInHierarchy)
                {

                //enter conversation
                conversationThree.SetActive(true);
                 PlaySound(nPCVoice);
                
                }
                else if(Input.GetKeyDown(KeyCode.E) && conversationThree.activeInHierarchy)
                {
                 conversationThree.SetActive(false);
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
        conversationOne.SetActive(false);
        conversationTwo.SetActive(false);
        conversationThree.SetActive(false);
    }
}
