using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeableObject : MonoBehaviour
{
    public GameObject targetObject;
    private UnityEngine.UI.Button button;
    private WallChecker wallChecker;
    // Start is called before the first frame update
    void Start()
    { 
        button = GetComponent<UnityEngine.UI.Button>();
        wallChecker = GetComponent<WallChecker>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onClick()
    {
        targetObject.GetComponent<UpgradeTarget>().setActive();
        button.enabled = false;
        wallChecker.clickable = false;
    }
}
