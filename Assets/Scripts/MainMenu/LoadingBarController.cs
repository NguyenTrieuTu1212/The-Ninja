using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingBarController : MonoBehaviour
{

    public TextMeshProUGUI percentText;
    public Slider loadingSlider;

    private float currentProgress = 0f;
    private float targetProgress = 100f;
    private float speed = 0f;

    void Start()
    {
        StartCoroutine(UpdateLoadingBar());
    }

    IEnumerator UpdateLoadingBar()
    {
        while (currentProgress < targetProgress)
        {
            UpdateSpeed();

            currentProgress += speed * Time.deltaTime;
            currentProgress = Mathf.Clamp(currentProgress, 0f, 100f);

            loadingSlider.value = currentProgress / 100f;
            percentText.text = $"Loading..... {Mathf.RoundToInt(currentProgress)} %";

            yield return null;
        }
        percentText.text = "Finish";
        ScenesTrasitionManager.Instance.NextLevel("MenuScenes");
    }

    void UpdateSpeed()
    {
        if (currentProgress < 60f)
        {
            speed = 10f; // T?c ð? nhanh t? 0 ð?n 60
        }
        else if (currentProgress < 90f)
        {
            speed = 7f; // T?c ð? b?nh thý?ng t? 60 ð?n 90
        }
        else
        {
            speed = 4f; // Ch?m l?i t? 90 ð?n 100
        }
    }
}
