using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using VRTK;
using Zinnia.Haptics;

public class TaskController : MonoBehaviour
{
    public GameObject task;
    public GameObject otherController;
    public List<string> taskObservations;
    private const string taskHeaderWithTime = "time_ms,pos_x,pos_y,pos_z,rot_x,rot_y,rot_z";


    private void Start()
    {

    }
    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            task.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            task.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("hihi enabled");
            SaveTasks();
        }
    }

    public void SaveTasks()
    {
        Debug.Log("attempting to save the tasks");
        Debug.Log("task len:" + taskObservations.Count);
        var startTime = DateTimeOffset.UtcNow.ToUnixTimeSeconds() * 1000f;
        RecordTrackedAlias.SavePositionsAndRotationsToDiskAndAnalyze(taskHeaderWithTime, taskObservations,
            $"taskTracking_{startTime:F4}");
    }

    public void LockTransformToController()
    {
        Debug.Log("attempting to lock controller");
        task.transform.SetPositionAndRotation(otherController.transform.position + otherController.transform.forward*0.2f, otherController.transform.rotation);
    }
} 