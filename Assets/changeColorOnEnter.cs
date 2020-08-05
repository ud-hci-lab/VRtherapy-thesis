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
        
    }


    public void ResetToRed()
    {
        mMaterial.color = pre;
        hasBeenGreened = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //ensure that the colder is not another part of the model
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
        var x = RecordTrackedAlias.Tracked6DString(aliasControllerScript.controllerR.transform);
        var timeString = RecordTrackedAlias.GameMillisToString();
        var combinedObservation = timeString + "," + x;
        taskControllerScript.taskObservations.Add(combinedObservation);
    }
}