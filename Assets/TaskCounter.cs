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
    //public GameObject victoryChick;
    public GameObject fishDots;
    public GameObject chickDots;
    private int success;

    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject cube1;
    public GameObject cube2;
    //public GameObject afterCube1;
    //public GameObject afterCube2;

    // Start is called before the first frame update
    private void Start()
    {
        Debug.Log("afters start taskCounter: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + cube1.activeSelf + " " + cube2.activeSelf);
        Debug.Log("this: "+ this + "get component " + this.GetComponent<TextMeshProUGUI>());
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "Dots Completed: 0";
        victory= victoryObj.GetComponent<ParticleSystem>();
        victoryFish.SetActive(false);
        success = 0;
        //victoryChick.SetActive(false);
        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        cube1.SetActive(false);
        cube2.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (taskControllerScript == null)
        {
            if (GameObject.FindGameObjectWithTag("Task"))
            {
                taskControllerScript = GameObject.FindGameObjectWithTag("Task").GetComponent<TaskController>();
                if (GameObject.FindGameObjectWithTag("Task").name == "ChickenTask")
                {
                    totalCount = "/150";
                    totalInt = 150;
                }
                else
                {
                    totalCount = "/69";
                    totalInt = 69;
                }
            }
        }
        else
        {
            if (Time.frameCount % 10 == 0)
            {
                tmp.text = taskControllerScript.tasksAchieved + totalCount;
                if (taskControllerScript.tasksAchieved == totalInt && success == 0)
                {
                   // Debug.Log("VICTORY");
                    victory.Play(true);
                    victoryObj.transform.position = new Vector3(0, 0, 0);

                    if (GameObject.FindGameObjectWithTag("Task").name == "FishTask")
                    {
                        victoryFish.SetActive(true);
                        fishDots.SetActive(false);
                    }
                    else
                    {
                        //victoryChick.SetActive(true);
                        chickDots.SetActive(false);
                    }

                    Debug.Log("SUCCESS " + success);
                    if (success == 0)
                    {
                        Invoke("stop", 5.0f);
                    }
                }
            }
        }
    }

    private void stop()
    {
        Debug.Log("STOP");
        Debug.Log("afters stop taskCounter: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + cube1.activeSelf + " " + cube2.activeSelf);
        victoryFish.SetActive(false);
        victory.Stop(true);
        if (success == 0)
        {
            afterMenu1.SetActive(true);
            afterMenu2.SetActive(true);
            cube1.SetActive(true);
            cube2.SetActive(true);
        }
        success += 1;
        //cube1.transform.position = new Vector3(0.03f, 2.03f, 0.5f);
        //cube2.transform.position = new Vector3(0.02f, 1.2f, 0.5f);
    }
}
