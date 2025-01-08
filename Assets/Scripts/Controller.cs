using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void NextScene()
    {
        SceneManager.LoadScene("Scenes/MainGame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
