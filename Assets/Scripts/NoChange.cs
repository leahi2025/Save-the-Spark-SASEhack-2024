using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NoChange : MonoBehaviour
{
    private UnityEngine.UI.Button button;
    private WallChecker wallChecker;
    public void Start()
    {
        button = GetComponent<UnityEngine.UI.Button>();
        wallChecker = GetComponent<WallChecker>();
    }
    public void onClick()
    {
        EventSystem.current.SetSelectedGameObject(null);
        button.enabled = false;
        wallChecker.clickable = false;
    }
}
