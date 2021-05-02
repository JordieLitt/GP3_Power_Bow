using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToAppear : MonoBehaviour
{
    public bool isShot = false;

    public GameObject item;

    AudioSource targetSource;
    public AudioClip complete;

    // Start is called before the first frame update
    void Start()
    {
        targetSource= GetComponent<AudioSource>();

        item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isShot == true)
        {
            item.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Arrow2")
        {
            if(isShot == false)
            {
                isShot = true;
                item.SetActive(true);
                PlaySound(complete);
            }
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
