using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        gameObject.SetActive(false);
    }

    public void OpenPanelSetting()
    {
        gameObject.SetActive(true);
        animator.SetBool("isHide", false);
    }

    public void ClosePanelSetting()
    {
        AudioManager.Instance.PlaySFX("Click");
        animator.SetBool("isHide", true);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    
}
