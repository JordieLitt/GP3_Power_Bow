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
    public MaterialChange matChange;

    // This is used specifcally for the duration.
    public static event System.Action<float> OnAstralProject;
    public static event System.Action OnAstralProjectCancel;

    void Start()
    {
        g = GameObject.FindGameObjectWithTag("materialCh");
        
        matChange = g.GetComponent<MaterialChange>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !abilityActive && unlockedAstral == true)
        {
            energyBar.SetActive(true);
            energyBall.SetActive(true);
            player2 = Instantiate(player2Prefab, transform.position, transform.rotation);
            player2.transform.Rotate(0, 0, 0);
            // Logically, _astralModeCour should always be null once reaching this point since one Coroutine runs at a time.
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
            _astralModeCour = null;
        }
    }

    // ResetPosition() creates a new instance of IEnumerator, it is not a static instance that can be referenced again.
    // StopCoroutine(ResetPositon ()) does not reference the running couroutine that was started, it needs to be cached
    private IEnumerator ResetPosition()
    {
        abilityActive = true;

        matChange.SetDuration(this.duration);
        OnAstralProject?.Invoke(duration);
        yield return new WaitForSeconds(duration);
        player.transform.position = player2.transform.position;
        Destroy(player2.gameObject);
        abilityActive = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name =="astralPickup")
        {
            unlockedAstral = true;
            Destroy(col.gameObject);
            matChange.astralUnlock = true;
        }
    }
}
