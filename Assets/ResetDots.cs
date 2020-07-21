using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDots : MonoBehaviour
{
    // Start is called before the first frame update
    private changeColorOnEnter[] colorChangerScriptList;
    private TaskController taskControllerScript;
    private void Start()
    {
        colorChangerScriptList = transform.GetChild(0).GetChild(0).GetComponentsInChildren<changeColorOnEnter>(); //get child 0.get child 0
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
            Debug.Log("resetting!");
        }
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        taskControllerScript.tasksAchieved = 0;
    }
}
