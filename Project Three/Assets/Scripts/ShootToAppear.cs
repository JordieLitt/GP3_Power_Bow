using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootToAppear : MonoBehaviour
{
    public bool isShot = false;

    public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
        item.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isShot == true)
        {
            item.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Arrow2")
        {
            isShot = true;
        }
    }
}
