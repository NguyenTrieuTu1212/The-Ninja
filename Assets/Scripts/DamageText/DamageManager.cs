using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : Singleton<DamageManager>
{
    
    [SerializeField] private List<DamageText> damagePrefabs;
    [SerializeField] private Queue<DamageText> activeDamageText;
    [SerializeField] private Transform poolPanel;
    [SerializeField] private int amount;
    


    protected override void Awake()
    {
        base.Awake();
        
        damagePrefabs = new List<DamageText>();
        activeDamageText = new Queue<DamageText>();
        AddPrefabs();
        Prepare();
    }



    private void AddPrefabs()
    {
        Transform objPrefs = transform.Find("Prefabs");
        if (objPrefs == null) return;
        foreach(Transform obj in objPrefs)
        {
            damagePrefabs.Add(obj.GetComponent<DamageText>());
        }
        HidePrefabs();
    }


    private void HidePrefabs()
    {
        foreach (DamageText damageText in damagePrefabs)
        {
            damageText.gameObject.SetActive(false);
        }
    }


    private void Prepare()
    {
        for(int i=0;i < amount; i++)
        {
            DamageText damageText = Instantiate(damagePrefabs[0], poolPanel);
            damageText.gameObject.SetActive(false);
            activeDamageText.Enqueue(damageText);
        }
    }


    public DamageText TakeDamageText(float damageAmount)
    {
        if (activeDamageText.Count <= 0) Prepare();
        DamageText damageText = activeDamageText.Dequeue();
        damageText.SetTextDamageTMP(damageAmount);
        damageText.gameObject.SetActive(true);
        return damageText;
    }


    public void ReturnDamageText(DamageText damageText)
    {
        activeDamageText.Enqueue(damageText);
        damageText.transform.SetParent(poolPanel);
        damageText.gameObject.SetActive(false);
    }    

}
