using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool inRange = false;
    public GameObject message;
    public bool hasPulled = false;
    public GameObject platforms;
    public GameObject gate;

    AudioSource targetSource;
    public AudioClip unlocked;

    // Start is called before the first frame update
    void Start()
    {
        targetSource = GetComponent<AudioSource>();

        platforms.SetActive(true);
        message.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange == true && hasPulled == false)
        {
            message.SetActive(true);
        }

        if(inRange == true && Input.GetKeyDown(KeyCode.E))
        {
            if(hasPulled == false)
            {
                PlaySound(unlocked);
                hasPulled = true;
                platforms.SetActive(false);
                gate.transform.position  += new Vector3 (0f, 7.45f, 0f);
            }
        }

        if(hasPulled == true)
        {
            message.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            inRange = true;
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
