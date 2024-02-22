using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    [SerializeField] private SettingMenu settingMenu;


    public void DisplaySettingPanel()
    {
        AudioManager.Instance.PlaySFX("Click");
        settingMenu.OpenPanelSetting();
    }

    public void PlayGame()
    {
        AudioManager.Instance.PlaySFX("Click");
        /*SceneManager.LoadSceneAsync("MainScenes");*/
        ScenesTrasitionManager.Instance.NextLevel("MainScenes");
    }


    public void ExitGame()
    {
        AudioManager.Instance.PlaySFX("Click");
        Application.Quit();
    }
}
