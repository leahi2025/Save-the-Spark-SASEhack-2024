using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonHandler : MonoBehaviour
{
    private DisplayImage currentDisplay;
    public UnityEvent sceneChanged;

    private void Start()
    {
        currentDisplay = GameObject.Find("displayObject").GetComponent<DisplayImage>();
    }

    public void OnRightClickArrow()
    {
        currentDisplay.CurrentWall++;
        sceneChanged.Invoke();
    }
    public void OnLeftClickArrow()
    {
        currentDisplay.CurrentWall--;
        sceneChanged.Invoke();
    }
}
