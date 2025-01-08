using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PriceSetter : MonoBehaviour
{
    public double price;
    private TextMeshProUGUI priceText;
    public TimeManager timeManager;
    // Start is called before the first frame update
    void Awake()
    {
        timeManager = GameObject.Find("TimeKeeper").GetComponent<TimeManager>();
        priceText = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("setText", 0.01f, timeManager.dayDuration / 24f);
        setText();
    }


    private void setText()
    {
        getPrice(Mathf.FloorToInt(timeManager.GetHour()));
        priceText.text = "Energy Price: $" + price.ToString("0.00") + "/kWh";
    }

    public double getPrice(int time)
    {
        if (time >= 0 && time <= 8)
        {
            price = (1.0 / 25.0) * Math.Pow((time - 5), 2) + 0.6;
        } else if (time > 8 && time <= 16)
        {
            price = (1.0 / 9.0) * time;
        } else if (time > 16 && time <= 19)
        {
            price = -1.0 * Math.Pow((((1.0 / 1.8) * time) - 10.6), 2) + 4.8;
        } else if (time > 19 && time <= 23)
        {
            price = -1.0 * Math.Sqrt(2 * time - 38) + 5;
        }
        return price;
    }
}
