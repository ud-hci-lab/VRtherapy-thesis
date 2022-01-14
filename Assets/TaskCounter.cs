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
    public GameObject victorySquare;
    public GameObject fishDots;
    public GameObject chickDots;
    public GameObject squareDots;
    public GameObject threeDfishDots;
    
    private int success;
    public bool unlockVictory; 

    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject cube1;
    public GameObject cube2;

    public string currentTask;

    // Start is called before the first frame update
    public void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "Dots Completed: 0";
        victory= victoryObj.GetComponent<ParticleSystem>();
        victory.Stop(true);
        victoryFish.SetActive(false);
        success = 0;
        victoryChick.SetActive(false);
        victorySquare.SetActive(false);
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
        Debug.Log("TC UPDATE");
        if (taskControllerScript == null)
        {
            Debug.Log("TC IF");
            if (currentTask == "ChickenTask")
            {
                taskControllerScript = GameObject.Find("ChickenTask").GetComponent<TaskController>();
                Debug.Log("TC CHICK");
                totalCount = "/150";
                totalInt = 150;
            } 
            else if (currentTask == "FishTask")
            {
                taskControllerScript = GameObject.Find("FishTask").GetComponent<TaskController>();
                Debug.Log("TC FISH");
                totalCount = "/69";
                totalInt = 69;
            }
            else if (currentTask == "SquareTask")
            {
                taskControllerScript = GameObject.Find("SquareTask").GetComponent<TaskController>();
                Debug.Log("TC SQUARE");
                totalCount = "/40";
                totalInt = 40;
            } 
            else if (currentTask == "ThreeDFishTask")
            {
                taskControllerScript = GameObject.Find("ThreeDFishTask").GetComponent<TaskController>();
                Debug.Log("TC 3D Fish");
                totalCount = "/91";
                totalInt = 91;
            }

        }
        else
        {
            Debug.Log("TC ELSE");
            if (Time.frameCount % 10 == 0)
            {
                tmp.text = taskControllerScript.tasksAchieved + totalCount;

                unlockVictory = true;
                
                if (taskControllerScript.tasksAchieved == totalInt && success == 0 && unlockVictory == true)
                {
                    Debug.Log("VICTORY");
                    victory.Play(true);
                    victoryObj.transform.position = new Vector3(0, 0, 0);

                    if (currentTask == "FishTask" || currentTask == "ThreeDFishTask")
                    {
                        victoryFish.SetActive(true);
                        fishDots.SetActive(false);
                    }
                    else if (currentTask == "ChickenTask")
                    {
                        victoryChick.SetActive(true);
                        chickDots.SetActive(false);
                    }
                    else if (currentTask == "SquareTask")
                    {
                        victorySquare.SetActive(true);
                        squareDots.SetActive(false);
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
        Debug.Log("TC STOP");
        if (success == 0)
        {
            victoryFish.SetActive(false);
            victoryChick.SetActive(false);
            victorySquare.SetActive(false);
            victory.Stop(true);
            afterMenu1.SetActive(true);
            afterMenu2.SetActive(true);
            cube1.SetActive(true);
            cube2.SetActive(true);
            taskControllerScript.tasksAchieved = 0;
            taskControllerScript = null;
        }
        unlockVictory = false;
        success += 1;
    }
}
