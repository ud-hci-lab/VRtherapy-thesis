using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using VRTK;
using Zinnia.Haptics;

public class TaskController : MonoBehaviour
{
    public GameObject otherController;
    private int _framesSinceLastSave = 0;
    [HideInInspector]
    public List<string> taskObservations;
    private const string taskHeaderWithTime = "time_ms,pos_x,pos_y,pos_z,rot_x,rot_y,rot_z\n";


    private void Start()
    {

    }
    private void FixedUpdate()
    {
if (Input.GetKeyDown(KeyCode.Return) && _framesSinceLastSave >= 90)
        {
            Debug.Log("hihi enabled");
            SaveTasks();
            taskObservations.Clear();
            _framesSinceLastSave = 0;
        }

_framesSinceLastSave += 1;

        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
           transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
        }
    }

    public void SaveTasks()
    {
        Debug.Log("attempting to save the tasks");
        Debug.Log("task len:" + taskObservations.Count);
        var startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        RecordTrackedAlias.SavePositionsAndRotationsToDiskAndAnalyze(taskHeaderWithTime, taskObservations,
            $"recording_{startTime}_taskTracking");
        
    }

    public void LockTransformToController()
    {
        Debug.Log("attempting to lock controller");
        transform.SetPositionAndRotation(otherController.transform.position + otherController.transform.forward*0.2f, otherController.transform.rotation);
    }
} 