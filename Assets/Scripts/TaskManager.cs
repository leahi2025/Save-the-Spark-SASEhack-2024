using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks;

    private TextMeshProUGUI taskText;
    void Start()
    {
        taskText = GetComponent<TextMeshProUGUI>();
        updateText(); 
    }

    private void updateText()
    {
        string text = "";
        for (int i = 0; i < tasks.Count; i++)
        {
            text += "Task " + (i + 1).ToString() + ": ";
            text += tasks[i].name;
            text += " - " + (tasks[i].complete ? "Complete" : "Incomplete");
            text += "\n";
        }
        taskText.text = text;
    }

    public void setTaskComplete(int taskNum)
    {
        tasks[taskNum].complete = true;
        updateText();
    }

    [System.Serializable]
    public class Task
    {
        public string name;
        public bool complete = false;
    }
}
