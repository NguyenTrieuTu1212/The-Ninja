using UnityEngine;

[CreateAssetMenu(fileName = "Playerstats", menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("Level of Player")]
    public int level;

    [Header("Health of Player")]
    public float Health;
    public float maxHealth;

    [Header("Mana of Player")]
    public float mana;
    public float maxMana;

    [Header("EXP of Player")]
    public float currentExp;
    public float expNextLevel;
    [Range(0f,100f)] public float expMultiplier;


    public void ResetStats()
    {
        maxHealth = 10;
        Health = maxHealth;

        maxMana = 20;
        mana = maxMana;

        level = 1;
        currentExp = 0f;
        expNextLevel = 100f;
    }
}