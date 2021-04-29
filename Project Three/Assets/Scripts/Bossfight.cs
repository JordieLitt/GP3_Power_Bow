using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfight : MonoBehaviour
{
    public Transform target;
    public float speed;
    public GameObject platforms;
    public GameObject finalPlat;
    public bool hit;
    public AudioSource ambience;
    public AudioSource bossPlayer;
    private Animator anim;


    void Start()
    {
        finalPlat.SetActive(false);
        ambience.Play();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(hit == true)
        {
            platforms.transform.position = new Vector3(334, 161, 428);
            Vector3 a = transform.position;
            Vector3 b = target.position;
            transform.position = Vector3.MoveTowards(a, b, speed);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            hit = true;

            if(ambience.isPlaying)
            {
                ambience.Stop();
                bossPlayer.Play();
                anim.enabled = true;
            }
        }
    }

    public void OnDestroy()
    {
        finalPlat.SetActive(true);
    }

}
