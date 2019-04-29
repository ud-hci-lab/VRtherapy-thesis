using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCTools : MonoBehaviour
{

    public static string DeltaTimeString(float priorTimeInSeconds)
    {
        return (Time.time - priorTimeInSeconds).ToString("F5");
    }
 
}
