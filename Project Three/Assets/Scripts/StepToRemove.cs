using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepToRemove : MonoBehaviour
{
    public GameObject platforms;

    public GameObject cubes1, cubes2, cubes3;

    public bool isSteppedOn = false;

    AudioSource targetSource;
    public AudioClip unlocked;

    // Start is called before the first frame update
    void Start()
    {
        targetSource = GetComponent<AudioSource>();

        cubes1.SetActive(true);
        cubes2.SetActive(true);
        cubes3.SetActive(true);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlaySound(unlocked);
            isSteppedOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isSteppedOn == true)
        {
            cubes1.SetActive(false);
            cubes2.SetActive(true);
            cubes3.SetActive(true);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
