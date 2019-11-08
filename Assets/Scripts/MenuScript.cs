using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject fishDots;
    public GameObject fishMenu;
    public GameObject fishButton;
    public GameObject chickenDots;
    public GameObject chickenMenu;
    public GameObject chickenButton;

    private void Start()
    {
        fishDots.SetActive(false);
        chickenDots.SetActive(false);
    }
    void OnCollisionEnter(Collision collide)
    {
        Debug.Log("collide (name) : " + collide.collider.gameObject.name);
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
