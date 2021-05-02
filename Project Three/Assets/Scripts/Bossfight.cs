using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossfight : MonoBehaviour
{
    public Transform target;
    public GameObject platforms;
    public GameObject finalPlat;
    public GameObject laserEye;
    public AudioSource ambience;
    public AudioSource bossPlayer;
    public AudioSource bossSounds;
    private Animator anim;
    public AudioClip intro;
    public bool hit;
    public bool isFiring;
    public float fireLength = 2f;
    public float coolDown = 2f;
    public float speed;


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

            Invoke("FireLaser",fireLength);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            hit = true;

            if(ambience.isPlaying)
            {
                anim.enabled = true;
                ambience.Stop();
                bossPlayer.Play();
                PlaySound(intro);
                Volleys();
            }
        }
    }

    public void OnDestroy()
    {
        finalPlat.SetActive(true);
    }

     public void PlaySound(AudioClip clip)
    {
        bossSounds.PlayOneShot(clip);
    }
    public void FireLaser()
    {
        laserEye.SetActive(true);
        isFiring = true;
    }
    public void CeaseFire()
    {
        laserEye.SetActive(false);
        isFiring = false;
    }

    public void Volleys()
    {
        if(!isFiring)
        {
            Invoke("FireLaser",fireLength);
        }
        if(isFiring)
        {
            Invoke("CeaseFire",coolDown);
        }
    }

}
