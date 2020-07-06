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
    private Animator taskAnimator;
    public GameObject victoryObj;
    private ParticleSystem victory;
    public GameObject victoryFish;
    //public GameObject victoryChick;
    public GameObject fishDots;
    public GameObject chickDots;

    // Start is called before the first frame update
    private void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "0";
        victory= victoryObj.GetComponent<ParticleSystem>();
        victoryFish.SetActive(false);
        //victoryChick.SetActive(false);
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
                if (taskControllerScript.tasksAchieved == totalInt && taskAnimator == null)
                {
                    Debug.Log("VICTORY");
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
                }
            }
        }
       
        
    }
}
