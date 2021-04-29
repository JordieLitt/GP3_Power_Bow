using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eyeShot : MonoBehaviour
{
    public int lives;
    public GameObject cyclops;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
       lives = 3;

       platform2.SetActive(false);
       platform3.SetActive(false); 
    }

    void Update()
    {
        LookAtPlayer();
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Arrow2")
        {
            lives -= 1;

            if(lives == 2)
            {
                platform1.SetActive(false);
                platform2.SetActive(true);
            }

            if(lives == 1)
            {
                platform2.SetActive(false);
                platform3.SetActive(true);
            }

            if(lives == 0)
            {
                platform3.SetActive(false);
                Destroy(cyclops);
            }
        }
    }

    void LookAtPlayer()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }
}
