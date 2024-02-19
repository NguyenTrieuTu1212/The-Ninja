using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISetting : MonoBehaviour
{

    [SerializeField] private Slider sliderMusicVolume;
    [SerializeField] private Slider sliderSFXVolume;
    [SerializeField] private TMP_Dropdown dropdownQuality;


    private void Start()
    {
        sliderMusicVolume.value = AudioManager.Instance.GetMusicVolume();
        sliderSFXVolume.value = AudioManager.Instance.GetSFXVolume();
        dropdownQuality.value = QualitySettings.GetQualityLevel();
    }


    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(sliderMusicVolume.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sliderSFXVolume.value);
    }

    /*private void OnEnable()
    {
        sliderMusicVolume.value = AudioManager.Instance.GetMusicVolume();
    }

    private void OnDisable()
    {
        sliderSFXVolume.value = AudioManager.Instance.GetSFXVolume();
    }*/
}
