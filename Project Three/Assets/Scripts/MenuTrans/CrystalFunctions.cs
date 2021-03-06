using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalFunctions : MonoBehaviour
{
     public Material baseMat, cleanseMat;
     public GameObject cleanseMessage;
    public bool atCrystal= false;
    public bool alreadyCleansed = false;
    public int expectedCount = 0;
    AudioSource cleanseSource;
    public AudioClip cleanseSound;

   

    void Start()
    {
        GetComponent<Renderer>().material = baseMat;
        cleanseSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        IsCleansed();
        CrystalCleanse();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
          if(!alreadyCleansed)
          {
            atCrystal = true;
          }
          if(alreadyCleansed)
          {
            atCrystal = false;
          }
        }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
          atCrystal = false;
          cleanseMessage.SetActive(false);
        }
    }

    void IsCleansed()
    {
        if(CrystalChecker.instance?.crystals >= expectedCount)
        {
            alreadyCleansed = true;
            GetComponent<Renderer>().material = cleanseMat;
        }
    }

    void CrystalCleanse()
    {
        if(atCrystal)
        {
            if(!alreadyCleansed)
            {
                cleanseMessage.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    PlaySound(cleanseSound);
                    CrystalChecker.instance.crystals += 1;
                    cleanseMessage.SetActive(false);
                }
            }
        }
        else
        {
            //close message
            cleanseMessage.SetActive(false);
        }
    }
    public void PlaySound(AudioClip clip)
    {
        cleanseSource.PlayOneShot(clip);
    }
}
