using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskCounter : MonoBehaviour
{
    private TaskController taskControllerScript;
    private TextMeshProUGUI tmp;
    private string totalCount;
    private int totalInt;

    public GameObject victoryObj;
    private ParticleSystem victory;
    public GameObject victoryFish;
    public GameObject victoryChick;
    public GameObject fishDots;
    public GameObject chickDots;
    private int success;
    public bool unlockVictory; 

    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject cube1;
    public GameObject cube2;

    public string currentTask;
    //public GameObject afterCube1;
    //public GameObject afterCube2;

    // Start is called before the first frame update
    public void Start()
    {
       // Debug.Log("afters start taskCounter: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + cube1.activeSelf + " " + cube2.activeSelf);
       // Debug.Log("this: "+ this + "get component " + this.GetComponent<TextMeshProUGUI>());
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "Dots Completed: 0";
        victory= victoryObj.GetComponent<ParticleSystem>();
        victory.Stop(true);
        victoryFish.SetActive(false);
        success = 0;
        victoryChick.SetActive(false);
        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        taskControllerScript = null;
        unlockVictory = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (taskControllerScript == null)
        { 
            if (currentTask == "ChickenTask")
            {

                taskControllerScript = GameObject.Find("ChickenTask").GetComponent<TaskController>();
                Debug.Log("TC CHICK");
                totalCount = "/150";
                totalInt = 150;
            } 
            else
            {
                taskControllerScript = GameObject.Find("FishTask").GetComponent<TaskController>();
                Debug.Log("TC FISH");
                totalCount = "/69";
                totalInt = 69;
            }
            /*
            if (GameObject.FindGameObjectWithTag("Task"))
            {
                taskControllerScript = GameObject.FindGameObjectWithTag("Task").GetComponent<TaskController>();
                if (GameObject.FindGameObjectWithTag("Task").name == "ChickenTask")
                {
                    Debug.Log("TC CHICK");
                    totalCount = "/150";
                    totalInt = 150;
                }
                else
                {
                    Debug.Log("TC FISH");
                    totalCount = "/69";
                    totalInt = 69;
                }
            }
            */
        }
        else
        {
            if (Time.frameCount % 10 == 0)
            {
                tmp.text = taskControllerScript.tasksAchieved + totalCount;

                Debug.Log("tasks achieved " + taskControllerScript.tasksAchieved);
                /*
                Debug.Log("unlock pre -3" + unlockVictory);
                if (taskControllerScript.tasksAchieved == (totalInt-3))
                {
                    Debug.Log("unlock -3" + unlockVictory);
                    unlockVictory = true;
                }
                */
                unlockVictory = true;
                
                if (taskControllerScript.tasksAchieved == totalInt && success == 0 && unlockVictory == true)
                {
                    Debug.Log("VICTORY");
                    victory.Play(true);
                    victoryObj.transform.position = new Vector3(0, 0, 0);

                    if (currentTask == "FishTask")
                    {
                        victoryFish.SetActive(true);
                        fishDots.SetActive(false);
                    }
                    else
                    {
                        victoryChick.SetActive(true);
                        chickDots.SetActive(false);
                    }

                    if (success == 0)
                    {
                        Invoke("Stop", 5.0f);
                    }
                }
            }
        }
    }

    private void Stop()
    {
        Debug.Log("STOP");
       // Debug.Log("afters stop taskCounter: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + cube1.activeSelf + " " + cube2.activeSelf);
        if (success == 0)
        {
            victoryFish.SetActive(false);
            victoryChick.SetActive(false);
            victory.Stop(true);
            afterMenu1.SetActive(true);
            afterMenu2.SetActive(true);
            cube1.SetActive(true);
            cube2.SetActive(true);
            taskControllerScript.tasksAchieved = 0;
            taskControllerScript = null;
        }
        // Debug.Log("FISH stop: " + fishDots.activeSelf + " " + fishDots.transform.position);
        unlockVictory = false;
        success += 1;
        Debug.Log("SUCCESS " + success);
    }

    /*
    public void ResetSuccess()
    {
        Debug.Log("RESET success");
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "Dots Completed: 0";
        victory = victoryObj.GetComponent<ParticleSystem>();
        victory.Stop(true);
        victoryFish.SetActive(false);
        success = 0;
        victoryChick.SetActive(false);
        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
        taskControllerScript = null;
        unlockVictory = false;
    }
    */
}
