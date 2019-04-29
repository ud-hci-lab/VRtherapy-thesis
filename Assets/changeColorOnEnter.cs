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
        taskControllerScript = transform.parent.parent.GetComponent<TaskController>();
    }


    public void ResetToGreen()
    {
        mMaterial.color = pre;
        hasBeenGreened = false;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        
        mMaterial.color = post;
        if (hasBeenGreened == false)
        {
            hasBeenGreened = true;
//            Debug.Log("Success hit at" + Time.time*1000f +". Hand Position:" + other.transform.position.ToString("F4")
            audd.Play();

            var x = RecordTrackedAlias.Tracked6DString(aliasControllerScript.controllerR.transform);
            var timeString = DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString("F4");
            taskControllerScript.taskObservations.Add(timeString);
            Debug.Log(timeString);
            
        }
        
    }

}