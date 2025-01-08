using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTarget : MonoBehaviour
{
    private UnityEngine.UI.Image image;
    private WallChecker wallChecker;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<UnityEngine.UI.Image>();
        wallChecker = GetComponent<WallChecker>();
        wallChecker.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setActive()
    {
        wallChecker.visible = true;
        wallChecker.checkWall();
    }
}
