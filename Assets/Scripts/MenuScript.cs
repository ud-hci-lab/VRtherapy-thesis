  using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject fishDots;
    public GameObject fishMenu;
    public GameObject fishButton;
    public GameObject chickenDots;
    public GameObject chickenMenu;
    public GameObject chickenButton;
    public GameObject pointer;
    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject afterCube1;
    public GameObject afterCube2;
    private TaskCounter TaskCounterScript;

    private void Start()
    {
       // Debug.Log("afters menu start: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + afterCube1.activeSelf + " " + afterCube2.activeSelf);
       // Debug.Log("befores menu start: " + fishButton.activeSelf + " " + chickenButton.activeSelf + " " + fishMenu.activeSelf + " " + chickenMenu.activeSelf);
        fishDots.SetActive(false);
        chickenDots.SetActive(false);
        fishButton.SetActive(true);
        chickenButton.SetActive(true);
        fishMenu.SetActive(true);
        chickenMenu.SetActive(true);
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
           // OnCollisionEnter(pointerEventData);
        }
    }

    void OnCollisionEnter(Collision collide)
    {
        //Debug.Log("Detected collision between " + gameObject.name + " and " + collide.collider.name + " THIS " + this);
    }

    public void FishIntialization()
    {
       // Debug.Log("afters menu fish: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + afterCube1.activeSelf + " " + afterCube2.activeSelf);
       // Debug.Log("befores menu fish: " + fishButton.activeSelf + " " + chickenButton.activeSelf + " " + fishMenu.activeSelf + " " + chickenMenu.activeSelf);
        fishDots.SetActive(true);
        Vector3 fishPosition = new Vector3(-0.038f, 1.38f, 1.33f);
        fishDots.transform.position = fishPosition;
        Debug.Log("FISH menu: " + fishDots.activeSelf + " " + fishPosition);
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        //Vector3 buttonPosition = new Vector3(-10f, -10f, -10f);
        //fishButton.transform.position = buttonPosition;
        //chickenButton.transform.position = buttonPosition;
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "FishTask";
    }

    public void ChickenIntialization()
    {
      //  Debug.Log("afters menu chick: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + afterCube1.activeSelf + " " + afterCube2.activeSelf);
       // Debug.Log("befores menu chick: " + fishButton.activeSelf + " " + chickenButton.activeSelf + " " + fishMenu.activeSelf + " " + chickenMenu.activeSelf);
        chickenDots.SetActive(true);
        Vector3 chickenPosition = new Vector3(-0.591f, 1.238f, 1.05f);
        chickenDots.transform.position = chickenPosition;
        fishButton.SetActive(false);
        chickenButton.SetActive(false);
        //Vector3 buttonPosition = new Vector3(-10f, -10f, -10f);
        //fishButton.transform.position = buttonPosition;
        //chickenButton.transform.position = buttonPosition;
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
        TaskCounterScript.Start();
        TaskCounterScript.currentTask = "ChickenTask";
        //  TaskCounterScript.ResetSuccess();
    }

    /*
    public void ReturnInitialization()
    {
        Debug.Log("afters menu return: " + afterMenu1.activeSelf + " " + afterMenu2.activeSelf + " " + afterCube1.activeSelf + " " + afterCube2.activeSelf);
        Debug.Log("befores menu return: " + fishButton.activeSelf + " " + chickenButton.activeSelf + " " + fishMenu.activeSelf + " " + chickenMenu.activeSelf);
        fishButton.SetActive(true);
        chickenButton.SetActive(true);
        fishMenu.SetActive(true);
        chickenMenu.SetActive(true);
        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        afterCube1.SetActive(false);
        afterCube2.SetActive(false);
    }

    public void QuitInitialization()
    {
        Application.Quit();
    }
    */
}
