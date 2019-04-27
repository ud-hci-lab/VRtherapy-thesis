using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using VRTK;
using Zinnia.Haptics;

public class resizeWithLeftController : MonoBehaviour
{
    public GameObject task;
    public GameObject otherController;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            task.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            task.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
        }
    }

    public void LockTransformToController()
    {
        
        task.transform.SetPositionAndRotation(otherController.transform.position + otherController.transform.forward*0.2f, otherController.transform.rotation);
    }
} 