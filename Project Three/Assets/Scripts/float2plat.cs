using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class float2plat : MonoBehaviour
{
    public GameObject target;

    AudioSource targetSource;
    public AudioClip unlocked;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();

        target.GetComponent<MeshRenderer>().enabled = false;
    }

     private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            PlaySound(unlocked);
            target.GetComponent<MeshRenderer>().enabled = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
