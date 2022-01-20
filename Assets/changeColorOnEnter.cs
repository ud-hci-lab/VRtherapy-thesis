using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class changeColorOnEnter : MonoBehaviour
{
    private Color pre = Color.red;
    private Color post = Color.green;
    Material mMaterial;

    private bool hasBeenGreened = false;
    private AudioSource audd;
    private TaskController taskControllerScript;
    private RecordTrackedAlias aliasControllerScript;

    private void Start()
    {
        mMaterial = GetComponent<Renderer>().material;
        mMaterial.color = pre;
        Debug.Log("<changeColorOnEnter><START> Material: " + mMaterial + "color: "+mMaterial.color);
        hasBeenGreened = false;
        aliasControllerScript = GameObject.Find("EventSystem").GetComponent<RecordTrackedAlias>();
        audd = GetComponent<AudioSource>();
        if (transform.parent.parent.tag == "Task")
        {
            taskControllerScript = transform.parent.parent.GetComponent<TaskController>();
            
        }
        else
        {
            taskControllerScript = transform.parent.parent.parent.GetComponent<TaskController>();
        }
        
        Debug.Log("<changeColorOnEnter><START> Set taskControllerScript to " + taskControllerScript);
    }

    public void ResetToRed()
    {
        mMaterial = GetComponent<Renderer>().material;
        Debug.Log("<changeColorOnEnter><Reset> Material: " + mMaterial);
        mMaterial.color = pre;
        hasBeenGreened = false;
        Debug.Log("<changeColorOnEnter><Reset> Done resetting to red : " + mMaterial.color);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //ensure that the collider is not another part of the model
        if (other.gameObject.tag == "PTAsset")
        {
            mMaterial.color = post;
            if (hasBeenGreened == false)
            {
                hasBeenGreened = true;
                audd.Play();

                AddObservationToList();
                taskControllerScript.tasksAchieved += 1;
            }
        }
    }

    private void AddObservationToList()
    {
        Debug.Log("<changeColorOnEnter><AddObservationToList> AddingObservationToList defined by " + taskControllerScript);
        var x = RecordTrackedAlias.Tracked6DString(aliasControllerScript.controllerR.transform);
        var timeString = RecordTrackedAlias.GameMillisToString();
        var combinedObservation = timeString + "," + x;
        taskControllerScript.taskObservations.Add(combinedObservation);
    }
}