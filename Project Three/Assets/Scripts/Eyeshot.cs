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
    public AudioSource bossSounds;
    public AudioClip bossDamage;
    public AudioClip bossDeath;
    public Animator cyclopsAnis;
    public bool damaged;
    public float invincibleTimer = 1;
    public bool isInvincible = false;
 

    void Start()
    {
       lives = 3;

       platform2.SetActive(false);
       platform3.SetActive(false); 
       cyclopsAnis = GetComponentInParent<Animator>();
    }

    void Update()
    {     
        //LookAtPlayer();
        damagedBoss();
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Arrow2")
        {
            if(!isInvincible)
            {  
            lives -= 1;
             

            if(lives == 2)
            {
                isInvincible = true;
                platform1.SetActive(false);
                platform2.SetActive(true);
                cyclopsAnis.SetBool("isDamaged", true);
                PlaySound(bossDamage);    
            }

            if(lives == 1)
            {
                isInvincible = true;
                platform2.SetActive(false);
                platform3.SetActive(true);
                cyclopsAnis.SetBool("isDamaged", true);
                PlaySound(bossDamage);              
            }

            if(lives == 0)
            {
                platform3.SetActive(false);
                PlaySound(bossDeath);
                cyclopsAnis.SetBool("isDying", true);
                Destroy(cyclops, 5.0f);
            }
            }
        }
    }

    void LookAtPlayer()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = rotation;
    }

      public void PlaySound(AudioClip clip)
    {
        bossSounds.PlayOneShot(clip);
    }

     public void damagedBoss()
     {
         if(isInvincible)
        {
            invincibleTimer -= Time.deltaTime;     
            if(invincibleTimer < 0)
            {
                isInvincible = false;
                invincibleTimer = 1;
                cyclopsAnis.SetBool("isDamaged", false); 
            }
        }
    }
}
