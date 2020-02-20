using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeBar : MonoBehaviour {
    private Mana mana;
    public Image spAtkBarImage;

    void Awake () {
        mana = new Mana();
    }

    void Update () {
        mana.Update();
        spAtkBarImage.fillAmount = mana.NormalizeMana();
    }

    public void UpdatePlayerSpAtk (float x) {
        spAtkBarImage.fillAmount -= x;
        if(spAtkBarImage.fillAmount > 0) {
            mana.UseMana(50);
            spAtkBarImage.fillAmount = 0;
        }
    }
}

public class Mana {
    public const int MAX_MANA = 100;

    private float manaAmount, manaRegenAmount;

    public Mana () {
        manaAmount = 0;
        manaRegenAmount = 10f;
    }

    public void Update () {
        if(manaAmount < MAX_MANA)
            manaAmount += manaRegenAmount * Time.deltaTime;
        if(manaAmount > MAX_MANA)
            manaAmount = MAX_MANA;
    }

    public void UseMana (int amount) {
        if(manaAmount >= amount) {
            manaAmount -= amount;
        }
    }

    public float NormalizeMana () {
        return manaAmount / MAX_MANA;
    }
}
