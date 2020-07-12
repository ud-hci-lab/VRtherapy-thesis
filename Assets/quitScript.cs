using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    void OnCollisionEnter(Collision collide)
    {
        Debug.Log("Collision");
        Debug.Log("Detected collision between " + gameObject.name + " and " + collide.collider.name + " THIS " + this);
        Application.Quit();
        Debug.Log("Application Quit");
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        Debug.Log("Detected collision between " + gameObject.name + " and " + other.name + " THIS " + this);
        Application.Quit();
        Debug.Log("Application Quit");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
