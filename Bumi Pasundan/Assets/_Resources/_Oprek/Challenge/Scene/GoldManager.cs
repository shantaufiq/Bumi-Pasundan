using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public int GoldValue = 15;
    public int Power = 5;
    public int DelayAmount = 1; // Second count
    public TextMeshProUGUI GoldValueText;
    public TextMeshProUGUI PowerText;

    protected float Timer;

    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            GoldValue++; // For every DelayAmount or "second" it will add one to the GoldValue
            GoldValueText.text = "Gold value: " + GoldValue;
            PowerText.text = "Power: " + Power;
        }
    }
}
