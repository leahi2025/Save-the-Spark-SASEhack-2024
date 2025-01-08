using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class setTooltip : MonoBehaviour
{
    TextMeshProUGUI displayedText;
    // Start is called before the first frame update
    void Start()
    {
        displayedText = GetComponent<TextMeshProUGUI>();
        hideTooltip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setToolTipTask(string text)
    {
        toolTipData data = new toolTipData(text);
        

        GameObject parent = transform.parent.gameObject;
        parent.SetActive(true);
        transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(data.xPos, data.yPos);
        string tipText = "";
        tipText += data.name + "\n";
        tipText += "Cost: " + data.price.ToString() + " kWh";
        displayedText.text = tipText;

    }

    public void setToolTipOptional(string text)
    {
        toolTipData data = new toolTipData(text);
        GameObject parent = transform.parent.gameObject;
        parent.SetActive(true);
        transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(data.xPos, data.yPos);
        string tipText = "";
        tipText += data.name + "\n";
        tipText += "Save " + data.price.ToString() + " kWh per hour";
        displayedText.text = tipText;

    }

    public void setToolTipUpgrade(string text)
    {
        toolTipLongData data = new toolTipLongData(text);
        GameObject parent = transform.parent.gameObject;
        parent.SetActive(true);
        transform.parent.GetComponent<RectTransform>().anchoredPosition = new Vector2(data.xPos, data.yPos);
        string tipText = "";
        tipText += data.origName + " uses " + data.prevkWh.ToString() + " kwh per hour\n";
        tipText += "Upgrade to " + data.newName + " for $" + data.upgradePrice + " - uses " + data.newkWh.ToString() + " kwh per hour";
        displayedText.text = tipText;
    }
    public void hideTooltip()
    {
        transform.parent.gameObject.SetActive(false);
    }

    private class toolTipData
    {
        public string name;
        public double price;
        public float xPos;
        public float yPos;

        public toolTipData(string text)
        {
            string[] parts = text.Split(',');
            string name = parts[0];
            double price;
            float xPos, yPos;
            double.TryParse(parts[1], out price);
            float.TryParse(parts[2], out xPos);
            float.TryParse(parts[3], out yPos);
            
            this.name = name;
            this.price = price;
            this.xPos = xPos;
            this.yPos = yPos;
        }
    }

    private class toolTipLongData
    {
        public string origName;
        public string newName;
        public double upgradePrice;
        public double prevkWh;
        public double newkWh;
        public float xPos;
        public float yPos;

        public toolTipLongData(string text)
        {
            string[] parts = text.Split(',');
            origName = parts[0];
            newName = parts[1];
            double.TryParse(parts[2], out upgradePrice);
            double.TryParse(parts[3], out prevkWh);
            double.TryParse(parts[4], out newkWh);
            float.TryParse(parts[5], out xPos);
            float.TryParse(parts[6], out yPos);
        }
    }
    
}
