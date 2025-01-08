using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SwitchableObject : MonoBehaviour
{
    public ESprite onSprite;
    public ESprite offSprite;
    public bool canSwitchBack;
    public bool state;
    private UnityEngine.UI.Image buttonImage;
    private RectTransform rectTransform;
    private UnityEngine.UI.Button button;
    private WallChecker wallChecker;
    // Start is called before the first frame update
    void Start()
    {
        buttonImage = GetComponent<UnityEngine.UI.Image>();
        button = GetComponent<UnityEngine.UI.Button>();
        rectTransform = GetComponent<RectTransform>();
        wallChecker = GetComponent<WallChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change()
    {

        EventSystem.current.SetSelectedGameObject(null);
        if (canSwitchBack)
        {
            state = !state;
            if (state)
            {
                buttonImage.sprite = onSprite.sprite;
                rectTransform.sizeDelta = new Vector2(onSprite.width, onSprite.height);
                rectTransform.anchoredPosition = new Vector2(onSprite.xPos, onSprite.yPos);
            }
            else
            {
                buttonImage.sprite = offSprite.sprite;
                rectTransform.sizeDelta = new Vector2(offSprite.width, offSprite.height);
                rectTransform.anchoredPosition = new Vector2(offSprite.xPos, offSprite.yPos);
            }
        } else
        { 
            if (state)
            {
                state = !state;
                buttonImage.sprite = offSprite.sprite;
                rectTransform.sizeDelta = new Vector2(offSprite.width, offSprite.height);
                rectTransform.anchoredPosition = new Vector2(offSprite.xPos, offSprite.yPos);
                button.enabled = false;
                wallChecker.clickable = false;
            }
        }
    }



    [System.Serializable]
    public class ESprite
    {
        public Sprite sprite;
        public float width;
        public float height;
        public float xPos;
        public float yPos;
    }
}
