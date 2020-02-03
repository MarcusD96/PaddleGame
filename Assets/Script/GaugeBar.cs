using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour
{
    private Mana mana;
    public Image playerBar, enemyBar, spAtkBar;


    private void Awake()
    {
        //playerBar = transform.Find("PlayerBar").GetComponent<Image>();
        playerBar.fillAmount = 1;

        //enemyBar = transform.Find("EnemyBar").GetComponent<Image>();
        enemyBar.fillAmount = 1;

        //spAtkBar = transform.Find("SpAtkBar").GetComponent<Image>();

        mana = new Mana();
    }

    private void Update()
    {
        mana.Update();

        spAtkBar.fillAmount = mana.NormalizeMana();
    }

    public void UpdatePlayerHealth(float x)
    {
        playerBar.fillAmount -= x; 
    }
    public void UpdateEnemyHealth(float x)
    {
        enemyBar.fillAmount -= x;
    }
    public void UpdatePlayerSpAtk(float x)
    {
        spAtkBar.fillAmount -= x;
    }

}

public class Mana
{
    public const int MAX_MANA = 100;

    private float manaAmount, ManaRegenAmount;

    public Mana()
    {
        manaAmount = 0;
        ManaRegenAmount = 30f;
    }

    public void Update()
    {
        manaAmount += ManaRegenAmount * Time.deltaTime;
    }

    public void UseMana(int amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }
    public float NormalizeMana()
    {
        return manaAmount / MAX_MANA;
    }
}
