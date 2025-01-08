using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;

public class DisplayImage : MonoBehaviour
{
    private const int numWalls = 3;
    public int CurrentWall
    {
        get { return currentWall; }
        set
        {
            if (value == numWalls + 1)
            {
                currentWall = 1;
            } else if (value == 0)
            {
                currentWall = numWalls;
            }
            else
            {
                currentWall = value;
            }
        }
    }

    private int currentWall = 1;
    private int previousWall;

    private void Start()
    {
        previousWall = 0;
        currentWall = 1;
    }

    private void Update()
    {
        if (currentWall != previousWall)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("LeahAssets/wall" +  currentWall.ToString());
        }

        previousWall = currentWall;
    }

}
