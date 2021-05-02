using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlatePlatforms : MonoBehaviour
{
    public GameObject platforms;
    public bool steppedOnOne = false;
    public bool steppedOnTwo = false;

    AudioSource targetSource;
    public AudioClip unlocked;

    public AudioClip complete;
    

    bool isDown = false;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();

        platforms.SetActive(false);
    }
    
    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PlaySound(unlocked);

            if(steppedOnOne == false)
            {
                steppedOnOne = true;
            }
            else
            {
                steppedOnTwo = true;
            }
        }
        
        if( steppedOnOne == true && steppedOnTwo == true)
        {
            if(!isDown)
            {
                PlaySound(complete);
                platforms.SetActive(true);
                isDown = true;
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
