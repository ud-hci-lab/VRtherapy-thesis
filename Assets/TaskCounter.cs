using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskCounter : MonoBehaviour
{
    private TaskController taskControllerScript;

    private TextMeshProUGUI tmp;
    // Start is called before the first frame update
    private void Start()
    {
        taskControllerScript = GameObject.Find("FishTask").GetComponent<TaskController>();
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "0/68";
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.frameCount %10 ==0)
        {
            tmp.text = taskControllerScript.tasksAchieved + "/68";
        }
        
    }
}
