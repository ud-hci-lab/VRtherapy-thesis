using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Application.Quit(); //only works when you build the project (doesn't work when you play in edit mode)
        Debug.Log("Application Quit");

    }

}
