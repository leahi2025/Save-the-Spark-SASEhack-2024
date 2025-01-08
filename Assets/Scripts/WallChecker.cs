using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WallChecker : MonoBehaviour
{
    private UnityEngine.UI.Button button;
    private DisplayImage currentDisplay;
    private UnityEngine.UI.Image buttonImage;
    public int onWall;
    public bool visible = true;
    public bool clickable = true;
    // Start is called before the first frame update
    void Start()
    {
        currentDisplay = GameObject.Find("displayObject").GetComponent<DisplayImage>();
        buttonImage = GetComponent<UnityEngine.UI.Image>();
        button = GetComponent<UnityEngine.UI.Button>();
        checkWall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void checkWall()
    {
        
        if (currentDisplay.CurrentWall == onWall)
        {
            if (button != null)
            {
                button.enabled = clickable;
            }
            if (buttonImage != null)
            {
                buttonImage.enabled = visible;
            } else
            {
                foreach (Image i in GetComponentsInChildren<Image>())
                {
                    i.enabled = visible;
                }
                foreach (TextMeshProUGUI t in GetComponentsInChildren<TextMeshProUGUI>())
                {
                    t.enabled = visible;
                }
            }
        }
        else
        {
            if (button != null)
            {
                button.enabled = false;
            }
            if (buttonImage != null)
            {
                buttonImage.enabled = false;
            }
            else
            {
                foreach (Image i in GetComponentsInChildren<Image>())
                {
                    i.enabled = false;
                }
                foreach (TextMeshProUGUI t in GetComponentsInChildren<TextMeshProUGUI>())
                {
                    t.enabled = false;
                }
            }
        }
    }
}
