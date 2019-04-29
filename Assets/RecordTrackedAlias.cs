using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class RecordTrackedAlias : MonoBehaviour
{
    public GameObject trackedAlias;

    private GameObject hmd;

    private GameObject controllerR;
    private List<string> trackedObservations = new List<string>();  
    private GameObject controllerL;
    // Start is called before the first frame update
    private void Start()
    {
        var aliasObject = trackedAlias.transform.GetChild(0);
        hmd = aliasObject.transform.GetChild(1).gameObject;
        controllerL = aliasObject.transform.GetChild(2).gameObject;
        controllerR = aliasObject.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    private static string Tracked6DString(GameObject trackedObject)
    {
        var position = trackedObject.transform.position;
        var rotation = trackedObject.transform.rotation;
        var outString =
            $"{position.x:F4},{position.y:F4},{position.z:F4},{rotation.eulerAngles.x:F4},{rotation.eulerAngles.y:F4},{rotation.eulerAngles.z:F4}";
        return outString;
    }

    private void SavePositionsAndRotationsToDiskAndAnalyze()
    {

       
        try
        {
            using (var fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ $"/textme_{Time.frameCount}.csv", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (var fw = new StreamWriter(fs))
                {
                    //header
                    fw.Write("time_ms,hmd_x,hmd_y,hmd_z,hmd_rot_x,hmd_rot_y,hmd_rot_z,lc_x,lc_y,lc_z,lc_rot_x,lc_rot_y,lc_rot_z,rc_x,rc_y,rc_z,rc_rot_x,rc_rot_y,rc_rot_z\n");

                    foreach (var t in trackedObservations)
                    {
                        fw.WriteLine(t);
                        Console.WriteLine(t + "_written");
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

    private void  Update()
    {
        var x = Time.time.ToString("F4" ) + "," + Tracked6DString(hmd) + "," + Tracked6DString(controllerL) +"," + Tracked6DString(controllerR);
        trackedObservations.Add(x);
        if (Time.frameCount % 90 == 0)
        {
            var startTime = Time.time;
            SavePositionsAndRotationsToDiskAndAnalyze();
            trackedObservations.Clear();
        }
    }


}
