using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    [SerializeField] private SettingMenu settingMenu;


    public void DisplaySettingPanel()
    {
        settingMenu.OpenPanelSetting();
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("MainScenes");
    }
}
