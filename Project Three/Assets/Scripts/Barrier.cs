using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    Collider barrier;
    public bool abilityActive = false;

    // Start is called before the first frame update
    void Start()
    {
        barrier = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive)
        {
            barrier.enabled = false;
            StartCoroutine(ResetPosition());
        }
    }

    private IEnumerator ResetPosition()
    {
        abilityActive = true;
        yield return new WaitForSeconds(10);
        barrier.enabled = true;
        abilityActive = false;
    }
}
