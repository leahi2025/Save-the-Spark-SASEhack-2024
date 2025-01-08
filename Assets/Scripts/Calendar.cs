using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    public TMP_Text dayText;
    public TimeManager timeManager;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.Find("TimeKeeper").GetComponent<TimeManager>();
        dayText = GameObject.Find("DayText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        dayText.SetText("Hour " + Mathf.FloorToInt(timeManager.GetHour()).ToString("0"));
    }
}
