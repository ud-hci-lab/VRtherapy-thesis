using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Unity.Collections;
using Unity.Jobs;

public class RecordTrackedAlias : MonoBehaviour
{
    public GameObject trackedAlias;

    private GameObject hmd;

    public GameObject controllerR;
    private static List<string> trackedObservations = new List<string>();  
    private GameObject controllerL;

    private string trackingHeaderWithTime =
        "time_ms,hmd_x,hmd_y,hmd_z,hmd_rot_x,hmd_rot_y,hmd_rot_z,lc_x,lc_y,lc_z,lc_rot_x,lc_rot_y,lc_rot_z,rc_x,rc_y,rc_z,rc_rot_x,rc_rot_y,rc_rot_z\n";
    // Start is called before the first frame update
    private void Start()
    {
        var aliasObject = trackedAlias.transform.GetChild(0);
        hmd = aliasObject.transform.GetChild(1).gameObject;
        controllerL = aliasObject.transform.GetChild(2).gameObject;
        controllerR = aliasObject.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    public static string Tracked6DString(Transform trackedTransform)
    {
        var position = trackedTransform.position;
        var rotation = trackedTransform.rotation;
        var outString =
            $"{position.x:F4},{position.y:F4},{position.z:F4},{rotation.eulerAngles.x:F4},{rotation.eulerAngles.y:F4},{rotation.eulerAngles.z:F4}";
        return outString;
    }

    public static void SavePositionsAndRotationsToDiskAndAnalyze(string headerString, List<string> observationsList, string fileName)
    {

       
        try
        {
            using (var fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ $"/{fileName}.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (var fw = new StreamWriter(fs))
                {
                    //header
                    fw.Write(headerString);

                    foreach (var t in observationsList)
                    {
                        fw.WriteLine(t);
                    }
                    fw.Flush(); // Added
                }
            }
        }
        catch(IOException)
        {
            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            Debug.LogError("FileStream not possible");
        }
        
    }

    private int _framesSinceLastSave = 0;
    private void  FixedUpdate()
    {
        var x = GameMillisToString() +
                "," +
                Tracked6DString(hmd.transform) +
                "," +
                Tracked6DString(controllerL.transform) +
                "," +
                Tracked6DString(controllerR.transform);
        trackedObservations.Add(x);

        if (Input.GetKeyDown(KeyCode.Return) && _framesSinceLastSave >= 90)
        {
             var startTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                    SavePositionsAndRotationsToDiskAndAnalyze(trackingHeaderWithTime, trackedObservations, $"recording_{startTime}_aliasTracking");
                    Debug.Log("completed save. elapsed seconds:" + BCTools.DeltaTimeString(startTime) + "and the frame count for save was " + _framesSinceLastSave);
                    _framesSinceLastSave = 0;
        }

        _framesSinceLastSave += 1;


    }

    public static string GameMillisToString()
    {
        return (Time.time*1000f).ToString("F0");
    }
}
