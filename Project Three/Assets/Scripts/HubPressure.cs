using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPressure : MonoBehaviour
{
    public GameObject platforms;

    public bool astraOn = false;

    AudioSource targetSource;
    public AudioClip unlocked;
    public bool activated =false;
   
    // Start is called before the first frame update
    void Start()
    {
        platforms.SetActive(false);
        targetSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if(activated == false)
            {
                PlaySound(unlocked);
            }
            
            astraOn = true;
            activated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(astraOn == true)
        {
            platforms.SetActive(true);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
