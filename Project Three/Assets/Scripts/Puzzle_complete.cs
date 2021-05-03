using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_complete : MonoBehaviour
{
    AudioSource targetSource;
    public AudioClip unlocked;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "gate")
        {
            PlaySound(unlocked);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
