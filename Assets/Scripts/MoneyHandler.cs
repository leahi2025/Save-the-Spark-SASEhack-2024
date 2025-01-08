using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MoneyHandler : MonoBehaviour
{
    public GameObject LosingScreen;
    public double amount;
    private TextMeshProUGUI moneyText;
    public TimeManager timeManager;
    public PriceSetter priceSetter;

    public SwitchableObject lamp;
    public SwitchableObject tv;
    public SwitchableObject shower;
    public Image fan;
    public SwitchableObject toilet;
    public SwitchableObject pipe;
    double price;
    public Dictionary<string, double> individualCosts = new Dictionary<string, double>();
    // Start is called before the first frame update
    void Awake()
    {
        amount = 500;
        moneyText = GetComponent<TextMeshProUGUI>();
        moneyText.text = "$" + 500.ToString();
        lamp = GameObject.Find("lamp").GetComponent<SwitchableObject>();
        individualCosts["Lamp"] = 0;
        tv = GameObject.Find("tv").GetComponent<SwitchableObject>();
        individualCosts["TV"] = 0;
        shower = GameObject.Find("shower").GetComponent<SwitchableObject>();
        individualCosts["Shower"] = 0;
        fan = GameObject.Find("Fan").GetComponent<Image>();
        individualCosts["AC/Fan"] = 0;
        toilet = GameObject.Find("toilet").GetComponent<SwitchableObject>();
        individualCosts["Toilet"] = 0;
        pipe = GameObject.Find("Pipe").GetComponent<SwitchableObject>();
        individualCosts["Pipe"] = 0;

        timeManager = GameObject.Find("TimeKeeper").GetComponent<TimeManager>();
        priceSetter = GameObject.Find("Price Display").GetComponent<PriceSetter>();

        LosingScreen.SetActive(false);

        InvokeRepeating("setText", 0.01f, timeManager.dayDuration / 24f);

    }
     

    // Update is called once per frame
    void Update()
    {
        if (amount < 0)
        {
            Time.timeScale = 0;
            LosingScreen.SetActive(true);
        }
    }
    private void setText()
    {
        price = priceSetter.getPrice(Mathf.FloorToInt(timeManager.GetHour()));
        double kWh = 0;

        if (lamp.state == true) { kWh += 1; individualCosts["Lamp"] += 1 * price; }
        if (tv.state == true) { kWh += 1.5; individualCosts["TV"] += 1.5 * price; }
        if (shower.state == true) { kWh += 5; individualCosts["Shower"] += 5 * price; }
        if (fan.enabled == true) { kWh += 1.5; individualCosts["AC/Fan"] += 1.5 * price; }
        else { kWh += 3.5; individualCosts["AC/Fan"] += 3.5 * price; }
        if (toilet.state == true) { kWh += 3; individualCosts["Toilet"] += 3 * price; }
        else { kWh += 1; individualCosts["Toilet"] += 1 * price; }
        if (pipe.state == true) { kWh += 2.5; individualCosts["Pipe"] += 2.5 * price; }
        else { kWh += 0.5; individualCosts["Lamp"] += 0.5 * price; }

        amount -= kWh * price;
        moneyText.text = "$" + Math.Round(amount, 2).ToString();
    }


    public void Upgrade(string appliance)
    {
        if (appliance == "fan")
        {
            amount -= 30;
            
        } else if (appliance == "toilet")
        {
            amount -= 50;
        } else if (appliance == "pipe")
        {
            amount -= 40;
        }
        moneyText.text = "$" + Math.Round(amount, 2).ToString();
    }

    public void completeTask(string task)
    {
        price = priceSetter.getPrice(Mathf.FloorToInt(timeManager.GetHour()));
        if (task == "cooking")
        {
            amount -= 1.5* price;
        } else if (task == "dishes")
        {
            amount -= 2 * price;
        } else if (task == "brush")
        {
            amount -= price;
        }
        moneyText.text = "$" + Math.Round(amount, 2).ToString();
    }
}
