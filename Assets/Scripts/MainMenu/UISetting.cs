using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{

    [SerializeField] private Slider sliderMusicVolume;
    [SerializeField] private Slider sliderSFXVolume;

    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(sliderMusicVolume.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(sliderSFXVolume.value);
    }
}
