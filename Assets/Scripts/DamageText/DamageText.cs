using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class DamageText : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI damageTMP;
    public void SetTextDamageTMP(float damage)
    {
        damageTMP.text = damage.ToString();
    }


    private void DestroyTMP()
    {
        DamageManager.Intance.ReturnDamageText(gameObject.GetComponent<DamageText>());
    }
}
