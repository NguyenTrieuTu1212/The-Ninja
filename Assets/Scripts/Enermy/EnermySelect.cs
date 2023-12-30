using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySelect : MonoBehaviour
{

    [SerializeField] GameObject selectorSprites;
    private EnermyBrain enermyBrain;

    private void Awake()
    {
        enermyBrain = GetComponent<EnermyBrain>();
        selectorSprites.SetActive(false);
    }


    private void EnermySelectedCallback(EnermyBrain enermySelected)
    {
        if (enermySelected == enermyBrain) selectorSprites.SetActive(true);
        else selectorSprites.SetActive(false);
    }

    public void NoEnermySelectedCallBack()
    {
        selectorSprites.SetActive(false);
    }


    private void OnEnable()
    {
        SelectorManager.OnSelectedEnermy += EnermySelectedCallback;
        SelectorManager.NoOnSelectedEnermy += NoEnermySelectedCallBack;
    }

    private void OnDisable()
    {
        SelectorManager.OnSelectedEnermy -= EnermySelectedCallback;
        SelectorManager.NoOnSelectedEnermy -= NoEnermySelectedCallBack;
    }
}
