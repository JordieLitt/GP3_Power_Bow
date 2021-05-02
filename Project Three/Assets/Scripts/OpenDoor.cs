using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool astraOn = false;
    public bool astra2On = false;
    public bool projection = false;
    public bool isOpened = false;
    public bool unlockedAstral = false;
    public bool check = false;

    public GameObject pPlate1;
    public GameObject pPlate2;
    public GameObject target;
    private GameObject m_plate;

    AudioSource targetSource;
    public AudioClip unlocked;
    public bool complete = false;


    // Start is called before the first frame update
    void Start()
    {
        targetSource = GetComponent<AudioSource>();

        target.SetActive(false);
        pPlate1.SetActive(false);
        pPlate2.SetActive(true);
        m_plate = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            projection = true;
            StartCoroutine(projectionEnd());
        }

        if(projection == true && astraOn == true && astra2On == true && complete == false)
        {
            PlaySound(unlocked);
            complete = true;
            isOpened = true;
            target.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            projection = false;
        }

        if(m_plate.GetComponent<ThirdPersonCharacterController>().onTop3)
        {
            astra2On = true;
            check = true;
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlaySound(unlocked);
        }

        if(collider.gameObject.tag == "Player" && projection == true)
        {
            astraOn = true;
            pPlate1.SetActive(true);
            pPlate2.SetActive(false);
        }

        if(collider.gameObject.tag == "Astra2" && projection == true)
        {
            astraOn = true;
            pPlate1.SetActive(true);
            pPlate2.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.tag == "Player" && projection == false)
        {
            astraOn = false;
        }
    }

    private IEnumerator projectionEnd()
    {
        yield return new WaitForSeconds(30);
        projection = false;
    }

    public void PlaySound(AudioClip clip)
    {
        targetSource.PlayOneShot(clip);
    }
}
