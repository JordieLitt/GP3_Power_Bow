using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubPressure : MonoBehaviour
{
    public GameObject floatingPlat1, floatingPlat2, floatingPlat3, floatingPlat4, floatingPlat5, floatingPlat6, floatingPlat7;

    public bool astraOn = false;
   
    // Start is called before the first frame update
    void Start()
    {
        floatingPlat1.SetActive(false);
        floatingPlat2.SetActive(false);
        floatingPlat3.SetActive(false);
        floatingPlat4.SetActive(false);
        floatingPlat5.SetActive(false);
        floatingPlat6.SetActive(false);
        floatingPlat7.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            astraOn = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(astraOn == true)
        {
            floatingPlat1.SetActive(true);
            floatingPlat2.SetActive(true);
            floatingPlat3.SetActive(true);
            floatingPlat4.SetActive(true);
            floatingPlat5.SetActive(true);
            floatingPlat6.SetActive(true);
            floatingPlat7.SetActive(true);
        }
    }
}
