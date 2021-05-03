using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCheats : MonoBehaviour
{
    public GameObject gateOne;
    public GameObject gateTwo;
    public GameObject gateThree;
    public GameObject gateFour;
    public GameObject enemyGroup;

    AudioSource targetSource;
    public AudioClip unlocked;

    void Start()
    {
        targetSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F2) )
        {
            gateOne.transform.position += new Vector3 (0f, 7.45f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.F3) )
        {
            PlaySound(unlocked);
            
            gateTwo.transform.position += new Vector3 (0f, 7.45f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.F4) )
        {
            gateThree.transform.position += new Vector3 (0f, 7.45f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.F5) )
        {
            gateFour.transform.position += new Vector3 (0f, 7.45f, 0f);
        }
        if(Input.GetKeyDown(KeyCode.F6) )
        {
            enemyGroup.transform.position += new Vector3 (0f, 100f, 0f);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
