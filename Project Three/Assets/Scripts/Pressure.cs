using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure : MonoBehaviour
{
    public GameObject platforms;
    public bool projection = false;

    AudioSource targetSource;
    public AudioClip unlocked;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();

        platforms.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            projection = true;
            StartCoroutine(projectionEnd());
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            platforms.SetActive(true);
        }

        if(collider.tag == "Astra2")
        {
            PlaySound(unlocked);
            platforms.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player" && projection == false)
        {
            platforms.SetActive(false);
        }

        if(collider.tag == "Astra2")
        {
            platforms.SetActive(false);
        }
    }

    private IEnumerator projectionEnd()
    {
        yield return new WaitForSeconds(10);
        projection = false;
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
