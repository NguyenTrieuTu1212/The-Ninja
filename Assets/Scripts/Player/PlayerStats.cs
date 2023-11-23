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


    public void ResetStats()
    {
        maxHealth = 10;
        Health = maxHealth;

        maxMana = 20;
        mana = maxMana;
        
    }
}