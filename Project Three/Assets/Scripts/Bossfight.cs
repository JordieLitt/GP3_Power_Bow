using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public bool hit = false;

    public GameObject bossPlats;
    // Start is called before the first frame update

    void Start()
    {
        bossPlats.SetActive(false);
    }

    void Update()
    {
        if(hit == true)
        {
            transform.position = Vector3.MoveTowards(startMarker.position, endMarker.position, 10f);
        }
    }

    private void OnTriggerEnter (Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            bossPlats.SetActive(true);
            hit = true;
        }
    }
}
