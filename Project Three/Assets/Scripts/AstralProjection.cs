using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstralProjection : MonoBehaviour
{
    private bool abilityActive = false;
    public bool unlockedAstral = false;

    public GameObject energyBar;
    public GameObject energyBall;
    public GameObject player2Prefab;
    public GameObject player;
    private GameObject player2;
    private GameObject g;
    private IEnumerator _astralModeCour;
    [SerializeField] private float duration;
    [SerializeField] private Material matNormal, matAstral;

    // This is used specifcally for the duration.
    public static event System.Action<float> OnAstralProject;
    public static event System.Action OnAstralProjectCancel;

    private Renderer matRenderer;

    void Start()
    {
        matRenderer = this.GetComponentInChildren<Renderer>();
        g = GameObject.FindGameObjectWithTag("materialCh");
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive && unlockedAstral == true)
        {
            energyBar.SetActive(true);
            energyBall.SetActive(true);
            player2 = Instantiate(player2Prefab, transform.position, transform.rotation);
            player2.transform.Rotate(0, 0, 0);
            matRenderer.material = matAstral;
            _astralModeCour = ResetPosition();
            StartCoroutine(_astralModeCour);
        }

        if(Input.GetKeyDown(KeyCode.R) && abilityActive == true)
        {
            energyBar.SetActive(false);
            energyBall.SetActive(false);
            player.transform.position = player2.transform.position;
            Destroy(player2.gameObject);
            abilityActive = false;
            OnAstralProjectCancel?.Invoke();
            StopCoroutine(_astralModeCour);
            matRenderer.material = matNormal;
            _astralModeCour = null;
        }
    }

    // ResetPosition() creates a new instance of IEnumerator, it is not a static instance that can be referenced again.
    // StopCoroutine(ResetPositon ()) does not reference the running couroutine that was started, it needs to be cached
    private IEnumerator ResetPosition()
    {
        abilityActive = true;

        OnAstralProject?.Invoke(duration);
        yield return new WaitForSeconds(duration);
        player.transform.position = player2.transform.position;
        Destroy(player2.gameObject);
        abilityActive = false;
        matRenderer.material = matNormal;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name =="astralPickup")
        {
            unlockedAstral = true;
            Destroy(col.gameObject);
        }
    }
}
