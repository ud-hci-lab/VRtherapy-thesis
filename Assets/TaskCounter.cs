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
    private GameObject victory1;
    private GameObject victory2;

    // Start is called before the first frame update
    private void Start()
    {
        tmp = this.GetComponent<TextMeshProUGUI>();
        tmp.text = "0";
        victory= victoryObj.GetComponent<ParticleSystem>();
       // victory1 = GameObject.FindGameObjectWithTag("TaskAnimation");
      //  victory1.SetActive(false);
        //victory2 = GameObject.FindGameObjectWithTag("Task").transform.GetChild(1).gameObject;
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
                   
                    //victory1.SetActive(true);
                    //Debug.Log(victory1.activeSelf);
                    //victory2.SetActive(false);
                }
            }
        }
       
        
    }
}
