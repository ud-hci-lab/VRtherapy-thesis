using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class showAtSpeed : MonoBehaviour
{
    public GameObject controllerPos;
    public float speedLimit = 0.005f;
    private Vector3 priorPos;

    private Renderer _renderer;
    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = controllerPos.transform.position;
        float speed = Vector3.Distance(currentPos, priorPos);
        _renderer = this.GetComponent<Renderer>();
        priorPos = currentPos;

        if (Math.Abs(speed) > speedLimit)
        {
            _renderer.enabled = true    ;
//            transform.position = new Vector3(0.75f, 2f, -2.77f);
        }
        else
        {
            _renderer.enabled = false    ;
//            transform.position = new Vector3(0f,-100f,0f);
        }
    }
}
