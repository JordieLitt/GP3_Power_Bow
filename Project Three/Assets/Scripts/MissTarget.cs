using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissTarget : MonoBehaviour
{
    AudioSource missSource;
    public AudioClip missClip;
    void Start()
    {
       missSource = GetComponent<AudioSource>();
    }

   private void OnTriggerEnter(Collider col)
   {
       if(col.gameObject.tag == "Arrow2")
       {
           PlaySound(missClip);
       }
   }

    public void PlaySound(AudioClip clip)
    {
        missSource.PlayOneShot(clip);
    }
}
