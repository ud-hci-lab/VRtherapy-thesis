using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject FishTask;
    public GameObject fishButton;

    public GameObject ThreeDFishTask;
    public GameObject threeDfishButton;

    public GameObject chickenTask;
    public GameObject chickenButton;

    public GameObject squareTask;
    public GameObject squareButton;
    
    
    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject afterCube1;
    public GameObject afterCube2;

    private TaskCounter TaskCounterScript;
    private ResetDots ResetDotsScript;

    private void Start()
    {
        FishTask.SetActive(false);
        chickenTask.SetActive(false);
        squareTask.SetActive(false);
        ThreeDFishTask.SetActive(false);

        fishButton.SetActive(true);
        chickenButton.SetActive(true);
        squareButton.SetActive(true);
        threeDfishButton.SetActive(true);

        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        afterCube1.SetActive(false);
        afterCube2.SetActive(false);

        TaskCounterScript = GameObject.Find("Progress Text (TMP)").GetComponent<TaskCounter>();
        
        // For testing
        //FishIntialization();
        //ThreeDfishIntialization();

        Debug.Log("<menu script><START> Started!");
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        //Use this to tell when the user right-clicks on the Button
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            //Output to console the clicked GameObject's name and the following message. You can replace this with your own actions for when clicking the GameObject.
            Debug.Log(name + " Game Object Right Clicked!");
        }
    }
    
    public void FishIntialization()
    {
        FishTask.SetActive(true);
        Vector3 fishPosition = new Vector3(-0.038f, 1.38f, 1.33f);
        FishTask.transform.position = fishPosition;
        Debug.Log("FISH menu: " + FishTask.activeSelf + " " + fishPosition);
        
        threeDfishButton.SetActive(false);
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        squareButton.SetActive(false);
        
        Debug.Log("<menuscript><FishInitialization> Starting TaskCounterScript");
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "FishTask";
        Debug.Log("<menuscript><FishInitialization> Successfully started TaskCounterScript: " + TaskCounterScript.currentTask);

        Debug.Log("<menuscript><FishInitialization> Starting ResetDotsScript for " + FishTask);
        ResetDotsScript = FishTask.GetComponent<ResetDots>();
        ResetDotsScript.task = TaskCounterScript.currentTask;
        ResetDotsScript.Start();
        ResetDotsScript.ResetAllDots();
    }

    public void ChickenIntialization()
    {
        chickenTask.SetActive(true);
        Vector3 chickenPosition = new Vector3(-0.591f, 1.238f, 1.05f);
        chickenTask.transform.position = chickenPosition;

        threeDfishButton.SetActive(false);
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        squareButton.SetActive(false);
        
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "ChickenTask";
        
        ResetDotsScript = chickenTask.GetComponent<ResetDots>();
        ResetDotsScript.task = TaskCounterScript.currentTask;
        ResetDotsScript.Start();
        ResetDotsScript.ResetAllDots();
    }

    public void SquareIntialization()
    {
        squareTask.SetActive(true);
        Vector3 squarePosition = new Vector3(-0.591f, 1.238f, 1.05f);
        squareTask.transform.position = squarePosition;
        
        threeDfishButton.SetActive(false);
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        squareButton.SetActive(false);

        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "SquareTask";

        ResetDotsScript = squareTask.GetComponent<ResetDots>();
        ResetDotsScript.task = TaskCounterScript.currentTask;
        ResetDotsScript.Start();
        ResetDotsScript.ResetAllDots();
    }

    public void ThreeDfishIntialization()
    {
        ThreeDFishTask.SetActive(true);
        Vector3 threeDfishPosition = new Vector3(-0.038f, 1.38f, 1.33f);
        ThreeDFishTask.transform.position = threeDfishPosition;
        Debug.Log("3D FISH menu: " + ThreeDFishTask.activeSelf + " " + threeDfishPosition);
        
        threeDfishButton.SetActive(false);
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        squareButton.SetActive(false);

        Debug.Log("<menuscript><3DfishInitialization> Starting TaskCounterScript");
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "ThreeDFishTask";
        Debug.Log("<menuscript><3DfishInitalization> Successfully started TaskCounterScript: " + TaskCounterScript.currentTask);

        Debug.Log("<menuscript><3DfishInitialization> Starting ResetDotsScript for " + ThreeDFishTask);
        ResetDotsScript = ThreeDFishTask.GetComponent<ResetDots>();
        ResetDotsScript.task = TaskCounterScript.currentTask;
        ResetDotsScript.Start();
        ResetDotsScript.ResetAllDots();
    }
}
