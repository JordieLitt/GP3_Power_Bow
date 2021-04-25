using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AstralEnergyUI : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = this.GetComponent<Slider>();
    }

    private void OnEnable()
    {
        AstralProjection.OnAstralProject += AdjustUI;
        AstralProjection.OnAstralProjectCancel += Canceled;

    }
    private void OnDisable()
    {
        AstralProjection.OnAstralProject -= AdjustUI;
        AstralProjection.OnAstralProjectCancel -= Canceled;
    }

    private void Canceled()
    {
        _slider.value = _slider.maxValue;

        StopAllCoroutines();
    }

    private void AdjustUI(float duration)
    {
        StartCoroutine(smoothValue(duration));
    }

    private IEnumerator smoothValue(float duration)
    {
        float value = duration;

        while(value > 0)
        {
            value -= Time.deltaTime;
            
            _slider.value = (value / duration);

            yield return new WaitForEndOfFrame();
        }

        _slider.value = 1;

        yield return null;
    }



}
