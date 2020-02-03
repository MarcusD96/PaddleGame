using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barImage;

    public void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        barImage.fillAmount = 1;
    }

    public void UpdateHealth(float x)
    {
        barImage.fillAmount -= x; 
    } 
}
