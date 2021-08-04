  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject fishTask;
    public GameObject fishMenu;
    public GameObject fishButton;
    public GameObject chickenTask;
    public GameObject chickenMenu;
    public GameObject squareButton;
    public GameObject squareTask;
    public GameObject squareMenu;
    public GameObject chickenButton;
    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject afterCube1;
    public GameObject afterCube2;
    private TaskCounter TaskCounterScript;
    private ResetDots ResetDotsScript;

    private void Start()
    {
        fishTask.SetActive(false);
        chickenTask.SetActive(false);
        squareTask.SetActive(false);
        fishButton.SetActive(true);
        chickenButton.SetActive(true);
        squareButton.SetActive(true);
        fishMenu.SetActive(true);
        chickenMenu.SetActive(true);
        squareMenu.SetActive(true);
        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        afterCube1.SetActive(false);
        afterCube2.SetActive(false);
        TaskCounterScript = GameObject.Find("Progress Text (TMP)").GetComponent<TaskCounter>();
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

    void OnCollisionEnter(Collision collide)
    {
        //Debug.Log("Detected collision between " + gameObject.name + " and " + collide.collider.name + " THIS " + this);
    }

    public void FishIntialization()
    {
        fishTask.SetActive(true);
        Vector3 fishPosition = new Vector3(-0.038f, 1.38f, 1.33f);
        fishTask.transform.position = fishPosition;
        Debug.Log("FISH menu: " + fishTask.activeSelf + " " + fishPosition);
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        squareButton.SetActive(false);
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
        squareMenu.SetActive(false);
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "FishTask";
        ResetDotsScript = fishTask.GetComponent<ResetDots>();
        ResetDotsScript.Start();
        ResetDotsScript.ResetAllDots();
    }

    public void ChickenIntialization()
    {
        chickenTask.SetActive(true);
        Vector3 chickenPosition = new Vector3(-0.591f, 1.238f, 1.05f);
        chickenTask.transform.position = chickenPosition;
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        squareButton.SetActive(false);
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
        squareMenu.SetActive(false);
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "ChickenTask";
        ResetDotsScript = chickenTask.GetComponent<ResetDots>();
        ResetDotsScript.Start();
        ResetDotsScript.ResetAllDots();
    }

    public void SquareIntialization()
    {
        squareTask.SetActive(true);
        Vector3 squarePosition = new Vector3(-0.591f, 1.238f, 1.05f);
        squareTask.transform.position = squarePosition;
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        squareButton.SetActive(false);
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
        squareMenu.SetActive(false);
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "SquareTask";
        ResetDotsScript = squareTask.GetComponent<ResetDots>();
        ResetDotsScript.Start();
        ResetDotsScript.ResetAllDots();
    }
}
