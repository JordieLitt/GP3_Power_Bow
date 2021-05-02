using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2 : MonoBehaviour
{
    public bool isOpened = false;

    public GameObject gate;

    public GameObject symbol;

    AudioSource targetSource;
    public AudioClip unlocked;

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
                gate.transform.position += new Vector3 (0f, 1.58f, 0f);
                PlaySound(unlocked);
                Destroy(symbol.gameObject);
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
