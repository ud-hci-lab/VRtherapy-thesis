using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDots : MonoBehaviour
{
    // Start is called before the first frame update
    private changeColorOnEnter[] colorChangerScriptList;
    private TaskController taskControllerScript;
    public string task;

    public void Start()
    {
        if (task == "ChickenTask")
        {
            colorChangerScriptList = transform.GetChild(0).GetChild(0).GetComponentsInChildren<changeColorOnEnter>();
        }
        else if (task == "FishTask")
        {
            colorChangerScriptList = transform.GetChild(1).GetComponentsInChildren<changeColorOnEnter>();
        }
        else if (task == "ThreeDfishTask")
        {
            colorChangerScriptList = transform.GetChild(0).GetComponentsInChildren<changeColorOnEnter>();
        }


        Debug.Log(colorChangerScriptList.Length + "dots to hit");

        if (taskControllerScript == null)
        {
            if (GameObject.FindGameObjectWithTag("Task"))
            {
                taskControllerScript = GameObject.FindGameObjectWithTag("Task").GetComponent<TaskController>();
            }
        }
    }


    // Update is called once per frame

    public void ResetAllDots()
    {
        Debug.Log("Reset values at" + Time.time * 1000f);
        foreach (var colorScript in colorChangerScriptList)
        {
            colorScript.ResetToRed();
        }
        Debug.Log("resetting!");
       // transform.GetChild(0).gameObject.SetActive(false);
      //  transform.GetChild(1).gameObject.SetActive(true);
        taskControllerScript.tasksAchieved = 0;
    }
}
