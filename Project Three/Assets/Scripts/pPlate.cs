using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pPlate : MonoBehaviour
{
    public GameObject target;
    public GameObject targetPrefab;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            target = Instantiate(targetPrefab, transform.position, transform.rotation);
            target.transform.position = new Vector3(0, 0, 0);
        }
    }
}
