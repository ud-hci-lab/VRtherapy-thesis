using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnScript : MonoBehaviour
{
    public GameObject fishMenu;
    public GameObject fishButton;
    public GameObject squareButton;
    public GameObject squareMenu;
    public GameObject chickenMenu;
    public GameObject chickenButton;
    public GameObject afterMenu1;
    public GameObject afterMenu2;
    public GameObject afterCube1;
    public GameObject afterCube2;

    private void OnTriggerEnter(Collider other)
    {
        afterMenu1.SetActive(false);
        afterMenu2.SetActive(false);
        afterCube1.SetActive(false);
        afterCube2.SetActive(false);
        Invoke("Wait", 1.0f);
    }

    //if press return to main menu, automatically presses the easy cube because it is in the same position when switched. so wait 2 seconds before switching the menus
    public void Wait()
    {
        fishButton.SetActive(true);
        chickenButton.SetActive(true);
        fishMenu.SetActive(true);
        chickenMenu.SetActive(true);
        squareMenu.SetActive(true);
        squareButton.SetActive(true);
    }

}
