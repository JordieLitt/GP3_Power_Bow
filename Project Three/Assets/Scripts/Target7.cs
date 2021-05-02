using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target7 : MonoBehaviour
{
    public bool isOpened = false;

    public GameObject gate;

    public GameObject symbol;
    
    AudioSource targetSource;
    public AudioClip unlocked;
    public AudioClip complete;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Arrow2")
        {
            if(isOpened == false)
            {
                isOpened = true;
                gate.transform.position += new Vector3 (0f, 7.45f, 0f);
                PlaySound(unlocked);
                PlaySound(complete);
                Destroy(symbol);
            }
        }
    }

     public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
