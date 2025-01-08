using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CostBreakdownSetter : MonoBehaviour
{

    public GameObject moneyHandlerObj;
    private MoneyHandler moneyHandler;
    TextMeshProUGUI displayedText;
    // Start is called before the first frame update
    void Start()
    {

        moneyHandler = moneyHandlerObj.gameObject.GetComponent<MoneyHandler>();
        displayedText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setText()
    {
        Debug.Log("called breakdown");
        foreach (var entry in moneyHandler.individualCosts)
        {
            displayedText.text += $"{entry.Key} : ${Math.Round(entry.Value, 2)}" + "\n";
        }
    }
}
