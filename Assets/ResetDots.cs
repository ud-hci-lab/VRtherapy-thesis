using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetDots : MonoBehaviour
{
    // Start is called before the first frame update
    private changeColorOnEnter[] colorChangerScriptList;
    private void Start()
    {
        colorChangerScriptList = transform.GetChild(1).GetComponentsInChildren<changeColorOnEnter>();
        Debug.Log(colorChangerScriptList.Length + "dots to hit");
    }

    // Update is called once per frame

    public void ResetAllDots()
    {
        Debug.Log("Reset values at" + Time.time*1000f);
        foreach (var colorScript in colorChangerScriptList)
        {
            colorScript.ResetToGreen();
            Debug.Log("resetting!");
        }
    }
}
