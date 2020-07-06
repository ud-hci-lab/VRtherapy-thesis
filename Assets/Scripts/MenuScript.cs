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

    private void Start()
    {
        fishDots.SetActive(false);
        chickenDots.SetActive(false);
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
        /*if(gameObject.name=="Cube" && collide.collider.gameObject.name=="DefaultMesh")
        {
            ChickenIntialization();
        } else if(gameObject.name=="Cube (1)" && collide.collider.gameObject.name == "DefaultMesh")
        {
            FishIntialization();
        }
        */
        Debug.Log("Detected collision between " + gameObject.name + " and " + collide.collider.name);
        Debug.Log("HELLO collide (name) : " + collide.collider.gameObject.name + " Collide: " + collide + " collide(name) : " + collide.collider.gameObject.name);
    }

    public void FishIntialization()
    {
        fishDots.SetActive(true);
        Vector3 fishPosition = new Vector3(-0.038f, 1.38f, 1.33f);
        fishDots.transform.position = fishPosition;
        Vector3 buttonPosition = new Vector3(-10f, -10f, -10f);
        fishButton.transform.position = buttonPosition;
        chickenButton.transform.position = buttonPosition;
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
    }

    public void ChickenIntialization()
    {
        chickenDots.SetActive(true);
        Vector3 chickenPosition = new Vector3(-0.591f, 1.238f, 1.05f);
        chickenDots.transform.position = chickenPosition;
        Vector3 buttonPosition = new Vector3(-10f, -10f, -10f);
        fishButton.transform.position = buttonPosition;
        chickenButton.transform.position = buttonPosition;
        fishMenu.SetActive(false);
        chickenMenu.SetActive(false);
    }



}
