using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public GameObject arrowPrefab2;
    public Transform arrowSpawn;
    public float shootForce = 20f;
    public float shootForce2 = 20f;
    
    public LineRenderer lineVisual;
    public int lineSegment;

    public Material mat1, mat2, mat3;

    public bool isHoldingDown1 = false;
    public bool isHoldingDown2 = false;

    //Audio
    AudioSource audioSource;
    public AudioClip drawBow;
    public AudioClip normalShot;

    void Start()
    {
        lineVisual.positionCount = lineSegment;
        audioSource= GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update()
    {
        LaunchArrows();
    }

    void LaunchArrows()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isHoldingDown1 = true;
            lineVisual.material = mat1;
            PlaySound(drawBow);
        }

        if(isHoldingDown1 == true)
        {
            GameObject go2 = arrowPrefab2;
            Rigidbody rb2 = go2.GetComponent<Rigidbody>();
            rb2.velocity = cam.transform.forward * shootForce2;
            Visualize(rb2.velocity);
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            GameObject go2 = Instantiate(arrowPrefab2, arrowSpawn.position, Quaternion.identity);
            Rigidbody rb2 = go2.GetComponent<Rigidbody>();
            rb2.velocity = cam.transform.forward * shootForce2;
            isHoldingDown1 = false;
            PlaySound(normalShot);
        }

        if(isHoldingDown1 == false && isHoldingDown2 == false)
        {
            lineVisual.material = mat3;
        }

        if (Input.GetMouseButtonDown(1))
        {
            isHoldingDown2 = true;
            lineVisual.material = mat2;
            PlaySound(drawBow);
        }

        if(isHoldingDown2 == true)
        {
            GameObject go = arrowPrefab;
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = cam.transform.forward * shootForce;
            Visualize(rb.velocity);
        }

        if (Input.GetMouseButtonUp(1))
        {
            GameObject go = Instantiate(arrowPrefab, arrowSpawn.position, Quaternion.identity);
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = cam.transform.forward * shootForce;
            isHoldingDown2 = false;
            PlaySound(normalShot);
        }

        if(isHoldingDown2 == false && isHoldingDown1 == false)
        {
            lineVisual.material = mat3;
        }
    }

    void Visualize(Vector3 vo)
    {
        for (int i = 0; i < lineSegment; i++)
        {
            Vector3 pos = CalculatePosInTime(vo, i/(float)(lineSegment)/0.5f);
            lineVisual.SetPosition(i, pos);
        }
    }

    Vector3 CalculatePosInTime(Vector3 vo, float time)
    {
        Vector3 Vxz = vo;
        Vxz.y = 0f;

        Vector3 result = arrowSpawn.position + vo * time;
        float sY = (-0.5f * Mathf.Abs(Physics.gravity.y) * (time * time)) + (vo.y * time) + arrowSpawn.position.y;

        result.y = sY;

        return result;
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
