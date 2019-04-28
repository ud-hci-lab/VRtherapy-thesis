using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordTrackedAlias : MonoBehaviour
{
    public GameObject trackedAlias;

    private GameObject hmd;

    private GameObject controllerR;
    private List<string> trackedObservations = new List<string>();  
    private GameObject controllerL;
    // Start is called before the first frame update
    void Start()
    {
        var aliasObject = trackedAlias.transform.GetChild(0);
        hmd = aliasObject.transform.GetChild(1).gameObject;
        controllerL = aliasObject.transform.GetChild(2).gameObject;
        controllerR = aliasObject.transform.GetChild(3).gameObject;
    }

    // Update is called once per frame

    void Update()
    {
        // hmd.transform.position.x, hmd.transform.rotation.eulerAngles;

        TrackedString(hmd);
    }

    private string TrackedString(GameObject trackedObject)
    {
        if (trackedObject.transform == null) return;
        var outString =
            $"{trackedObject.transform.position.x},{trackedObject.transform.position.y},{trackedObject.transform.position.z},{trackedObject.transform.rotation.eulerAngles.x},{trackedObject.transform.rotation.eulerAngles.y},{trackedObject.transform.rotation.eulerAngles.z}";
        return outString;
    }
}
