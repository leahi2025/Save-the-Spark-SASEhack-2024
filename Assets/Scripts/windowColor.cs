using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class windowColor : MonoBehaviour
{
    public Image window;
    public TimeManager timeManager;
    public int currWindow;
    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.Find("TimeKeeper").GetComponent<TimeManager>();
        window = GetComponent<Image>();
        window.sprite = Resources.Load<Sprite>("LeahAssets/window" + 1.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        float hour = timeManager.GetHour();
        if ((hour > 0 && hour <= 6) || (hour > 20 && hour <= 24)) {
            window.sprite = Resources.Load<Sprite>("LeahAssets/window" + 1.ToString());
            currWindow = 1;
        } else if ((hour > 6 && hour <= 8) || (hour > 18 && hour <= 20))
        {
            window.sprite = Resources.Load<Sprite>("LeahAssets/window" + 2.ToString());
            currWindow = 2;
        } else
        {
            window.sprite = Resources.Load<Sprite>("LeahAssets/window" + 3.ToString());
            currWindow = 3;
        }
    }
}
