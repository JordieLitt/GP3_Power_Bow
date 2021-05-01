using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepToReveal : MonoBehaviour
{
    public GameObject platform1, platform2, platform3, platform4, platform5, platform6;

    public GameObject path;

    public Material matNormal, matChanged;

    public bool onTopOf1;
    public bool onTopOf2;

    // Start is called before the first frame update
    void Start()
    {
        path.SetActive(false);

        platform1.GetComponent<Renderer>().material = matNormal;
        platform2.GetComponent<Renderer>().material = matNormal;
        platform3.GetComponent<Renderer>().material = matNormal;
        platform4.GetComponent<Renderer>().material = matNormal;
        platform5.GetComponent<Renderer>().material = matNormal;
        platform6.GetComponent<Renderer>().material = matNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if(onTopOf2 == false)
        {
            path.SetActive(false);

            platform1.GetComponent<Renderer>().material = matNormal;
            platform2.GetComponent<Renderer>().material = matNormal;
            platform3.GetComponent<Renderer>().material = matNormal;
            platform4.GetComponent<Renderer>().material = matNormal;
            platform5.GetComponent<Renderer>().material = matNormal;
            platform6.GetComponent<Renderer>().material = matNormal;
        }

        if(onTopOf1 == true)
        {
            path.SetActive(true);

            platform1.GetComponent<Renderer>().material = matChanged;
            platform2.GetComponent<Renderer>().material = matChanged;
            platform3.GetComponent<Renderer>().material = matChanged;
            platform4.GetComponent<Renderer>().material = matChanged;
            platform5.GetComponent<Renderer>().material = matChanged;
            platform6.GetComponent<Renderer>().material = matChanged;
        }

        if(onTopOf1 == false)
        {
            path.SetActive(false);

            platform1.GetComponent<Renderer>().material = matNormal;
            platform2.GetComponent<Renderer>().material = matNormal;
            platform3.GetComponent<Renderer>().material = matNormal;
            platform4.GetComponent<Renderer>().material = matNormal;
            platform5.GetComponent<Renderer>().material = matNormal;
            platform6.GetComponent<Renderer>().material = matNormal;
        }

        if(onTopOf2 == true)
        {
            path.SetActive(true);

            platform1.GetComponent<Renderer>().material = matChanged;
            platform2.GetComponent<Renderer>().material = matChanged;
            platform3.GetComponent<Renderer>().material = matChanged;
            platform4.GetComponent<Renderer>().material = matChanged;
            platform5.GetComponent<Renderer>().material = matChanged;
            platform6.GetComponent<Renderer>().material = matChanged;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            onTopOf1 = true;
        }

        if(collider.tag == "Astra2")
        {
            onTopOf2 = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
        {
            onTopOf1 = false;
        }
    }
}
