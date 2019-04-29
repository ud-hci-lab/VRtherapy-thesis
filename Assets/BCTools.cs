using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCTools : MonoBehaviour
{

    public static string DeltaTimeString(float priorTimeInSeconds)
    {
        return (DateTimeOffset.UtcNow.ToUnixTimeSeconds() - priorTimeInSeconds).ToString("F5");
    }
 
}
