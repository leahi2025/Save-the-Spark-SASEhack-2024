using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TimeManager : MonoBehaviour
{
    public const int hoursPerDay = 24;
    public const int minutesPerHour = 60;

    public GameObject LosingScreen;
    public GameObject WinningScreen;

    public float dayDuration = 45;

    float totalTime = 0;
    float currentTime = 0;

    public TaskManager taskManager;

    // Start is called before the first frame update
    void Awake()
    {
        
        taskManager = GameObject.Find("TaskList").GetComponent<TaskManager>();
        Time.timeScale = 1;
        totalTime = 0;
        currentTime = 0;
        InvokeRepeating("checkTasks", dayDuration, dayDuration);
    }

    // Update is called once per frame
    void Update()
    {
        totalTime += Time.deltaTime;
        currentTime = totalTime % dayDuration;
    }

    public float GetHour()
    {
        return currentTime * hoursPerDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (currentTime * hoursPerDay * minutesPerHour / dayDuration) % minutesPerHour;
    }

    public float GetDay()
    {
        return totalTime / dayDuration;
    }

    public void checkTasks()
    {
        for (int i = 0; i < taskManager.tasks.Count; i++)
        {
            if (!taskManager.tasks[i].complete)
            {
                Time.timeScale = 0;
                LosingScreen.SetActive(true);
            }
        }
        Time.timeScale = 0;
        WinningScreen.SetActive(true);
    }
}

