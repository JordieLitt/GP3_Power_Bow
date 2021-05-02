using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow_hit : MonoBehaviour
{
    AudioSource targetSource;
    public AudioClip unlocked;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Arrow2")
        {
            PlaySound(unlocked);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
