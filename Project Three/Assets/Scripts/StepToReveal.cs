using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepToReveal : MonoBehaviour
{
    public GameObject platform1, platform2, platform3, platform4, platform5;

    public Material matNormal, matChanged;

    public bool onTopOf;

    // Start is called before the first frame update
    void Start()
    {
        platform1.GetComponent<Renderer>().material = matNormal;
        platform2.GetComponent<Renderer>().material = matNormal;
        platform3.GetComponent<Renderer>().material = matNormal;
        platform4.GetComponent<Renderer>().material = matNormal;
        platform5.GetComponent<Renderer>().material = matNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if(onTopOf == true)
        {
            platform1.GetComponent<Renderer>().material = matChanged;
            platform2.GetComponent<Renderer>().material = matChanged;
            platform3.GetComponent<Renderer>().material = matChanged;
            platform4.GetComponent<Renderer>().material = matChanged;
            platform5.GetComponent<Renderer>().material = matChanged;
        }

        if(onTopOf == false)
        {
            platform1.GetComponent<Renderer>().material = matNormal;
            platform2.GetComponent<Renderer>().material = matNormal;
            platform3.GetComponent<Renderer>().material = matNormal;
            platform4.GetComponent<Renderer>().material = matNormal;
            platform5.GetComponent<Renderer>().material = matNormal;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            onTopOf = true;
        }

        if(collider.gameObject.name == "player2")
        {
            onTopOf = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.tag == "Player")
        {
            onTopOf = false;
        }

        if(collider.gameObject.name == "player2")
        {
            onTopOf = false;
        }
    }
}
