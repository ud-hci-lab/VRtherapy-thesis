using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectCoordinates : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        string filePath = "D:/chickenCoords.txt";
        string coordinates = "";
        var colliders = transform.GetChild(0).GetChild(2).GetComponentsInChildren<SphereCollider>();
        foreach (SphereCollider collider in colliders)
        {
            coordinates += "x: " + collider.center.x.ToString() + ", y: " + collider.center.y.ToString() + ", z: " + collider.center.z.ToString() + System.Environment.NewLine;
        }

        //Write the coords to a file
        System.IO.File.WriteAllText(filePath, coordinates);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
