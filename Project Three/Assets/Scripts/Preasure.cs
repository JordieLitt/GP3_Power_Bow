using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preasure : MonoBehaviour
{
    
    public bool steppedOn = false;
    AudioSource targetSource;
    public AudioClip unlocked;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        
        if(!steppedOn)
        {
            steppedOn = true;
            PlaySound(unlocked);
        }
        
    }
    bool GetBool()
    {
        return steppedOn;
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
