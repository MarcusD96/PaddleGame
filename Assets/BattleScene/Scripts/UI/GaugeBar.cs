using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GaugeBar : MonoBehaviour {
    private Mana mana;
    public Image spAtkBarImage;

    void Start () {
        mana = new Mana();
        foreach(var i in FindObjectsOfType<Image>()) {
            if(i.CompareTag("SpecialAttack")) {
                spAtkBarImage = i;
                break;
            }
        }
    }

    void Update () {
        mana.Update();
        spAtkBarImage.fillAmount = mana.NormalizeMana();
    }

    public void UpdatePlayerSpAtk (float x) {
        spAtkBarImage.fillAmount -= x;
        int manaUse = (int)(x * 100);
        if(spAtkBarImage.fillAmount > 0) {
            mana.UseMana(manaUse);
            spAtkBarImage.fillAmount = 0;
        }
    }

    public Image GetSpecialAttack() {
        return spAtkBarImage;
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
