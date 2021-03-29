using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    public Material matNormal, matAstral;

    public bool abilityActive = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = matNormal;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive)
        {
            GetComponent<Renderer>().material = matAstral;
            StartCoroutine(ResetPosition());
        }
    }

    private IEnumerator ResetPosition()
    {
        abilityActive = true;
        yield return new WaitForSeconds(10);
        GetComponent<Renderer>().material = matNormal;
        abilityActive = false;
    }
}
