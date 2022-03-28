using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    [Header("States & Attributes")]
    public float targetZoom = 7.5f;
    private bool startZoom = false;
    public float zoomIncrement = 0.1f;

    [Header("Reference Stuff")]
    public Camera Camera;

    private void Update()
    {
       if (startZoom == true && Camera.orthographicSize <= targetZoom)
       {
            Camera.orthographicSize += zoomIncrement * Time.deltaTime;
       }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            startZoom = true;
        }
    }
}
