using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private static DamageManager intance;
    public static DamageManager Intance { get => intance; }
    [SerializeField] private DamageText damageTextPrefs;
    [SerializeField] private List<Transform> damagePrefabs;


    private void Awake()
    {
        if(intance != null)
        {
            Debug.Log("More than 1 intance in your game");
            return;
        }
        damagePrefabs = new List<Transform>();   
        intance = this;
        AddPrefabs();
    }



    private void AddPrefabs()
    {
        Transform objPrefabs = transform.Find("Prefabs");
        if (objPrefabs == null) return;
        foreach (Transform objPrefab in objPrefabs)
            damagePrefabs.Add(objPrefab);
        HidePrefabs();
    }


    private void HidePrefabs()
    {
        foreach(Transform objPrefab in damagePrefabs) objPrefab.gameObject.SetActive(false);
    }

    public void SetTextDamage(float damageAmount,Transform parent)
    {
        DamageText damageText = Instantiate(damageTextPrefs,parent);
        damageText.transform.position += Vector3.right * 0.5f;
        damageText.SetTextDamageTMP(damageAmount);
    }


    

}
