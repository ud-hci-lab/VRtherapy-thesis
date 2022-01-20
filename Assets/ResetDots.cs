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
        if (task != null) 
        {
            Debug.Log("<reset_dots><START> task = " + task);

            if (task == "ChickenTask")
            {
                Debug.Log("<reset_dots><START> Chicken Task");
                colorChangerScriptList = transform.GetChild(0).GetChild(2).GetComponentsInChildren<changeColorOnEnter>();
            }
            else if (task == "FishTask")
            {
                Debug.Log("<reset_dots><START> FishTask");
                colorChangerScriptList = transform.GetChild(1).GetComponentsInChildren<changeColorOnEnter>();
            }
            else if (task == "ThreeDfishTask")
            {
                Debug.Log("<reset_dots><START> 3D Fish Task");
                colorChangerScriptList = transform.GetChild(0).GetComponentsInChildren<changeColorOnEnter>();
            }

            Debug.Log(colorChangerScriptList.Length + " dots to hit");

            if (taskControllerScript == null)
            {
                if (GameObject.FindGameObjectWithTag("Task"))
                {
                    taskControllerScript = GameObject.FindGameObjectWithTag("Task").GetComponent<TaskController>();
                }
            }
        }
        else
        {
           Debug.Log("<reset_dots><START> task = <null>"); 
        }
        
    }


    // Update is called once per frame

    public void ResetAllDots()
    {
        Debug.Log("Resetting " + colorChangerScriptList.Length + " points for " + task + " at "  + Time.time * 1000f);
        foreach (var colorScript in colorChangerScriptList)
        {
            colorScript.ResetToRed();
        }
        Debug.Log("Completed resetting all " + colorChangerScriptList.Length + " points for " + task + "!");
        // transform.GetChild(0).gameObject.SetActive(false);
        //  transform.GetChild(1).gameObject.SetActive(true);
        taskControllerScript.tasksAchieved = 0;
        Debug.Log("Done ResetAllDots "+taskControllerScript + " " + taskControllerScript.tasksAchieved);
    }
}
