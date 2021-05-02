using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect_sound : MonoBehaviour
{
    AudioSource targetSource;
    public AudioClip collect;
    public bool complete = false;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player" && complete == false)
        {
            PlaySound(collect);
            complete = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
