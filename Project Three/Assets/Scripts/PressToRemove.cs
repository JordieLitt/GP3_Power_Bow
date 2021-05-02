using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressToRemove : MonoBehaviour
{
    public GameObject platform, platform2;
    public GameObject target1;
    public GameObject target2;
    public bool isSteppedOn = false;
    AudioSource targetSource;
    public AudioClip waterDrain;

    // Start is called before the first frame update
    void Start()
    {
        targetSource = GetComponent<AudioSource>();
        platform.SetActive(true);
        platform2.SetActive(true);
        target1.SetActive(true);
        target2.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if(isSteppedOn == false)
            {
                isSteppedOn = true;
                PlaySound(waterDrain);
                platform.SetActive(false);
                platform2.SetActive(false);
                target1.SetActive(false);
                target2.SetActive(true);
            }
        }
    }
    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
