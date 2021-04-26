using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material matNormal, matAstral;

    public float duration;

    public bool abilityActive = false;

    public bool astralUnlock;

    public void SetDuration(float duration)
    {
        this.duration = duration;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = matNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive && astralUnlock == true)
        {
            GetComponent<Renderer>().material = matAstral;
            StartCoroutine(ResetPosition());
        }

        if(Input.GetKeyDown(KeyCode.R) && abilityActive == true)
        {
            GetComponent<Renderer>().material = matNormal;
            abilityActive = false;
            StopCoroutine(ResetPosition());
        }
    }

    private IEnumerator ResetPosition()
    {
        abilityActive = true;
        yield return new WaitForSeconds(duration);
        GetComponent<Renderer>().material = matNormal;
        abilityActive = false;
    }
}
