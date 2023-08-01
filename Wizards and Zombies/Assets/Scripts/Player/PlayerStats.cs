using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int health;
    [SerializeField] int xpNextLvl;
    [SerializeField] int xp;
    [SerializeField] int atackPower;
    [SerializeField] int atackSpeed;
    [SerializeField] int speed;
    [SerializeField] Slider healthBar;
    [SerializeField] Slider xpBar;

    public int GetStat(string stat)
    {
        if (stat == "atackPower")
        {
            return atackPower;
        }
        else if (stat == "atackSpeed")
        {
            return atackSpeed;
        }
        if (stat == "atackPower")
        {
            return atackPower;
        }
        else
        {
            return speed;
        }
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;

        healthBar.value = (float)health / (float)maxHealth;
        if (health <= 0)
        {
            //gameover
            print("Game Over");
        }
    }
}
