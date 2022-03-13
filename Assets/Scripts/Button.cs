using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isPressed = true;

            Debug.Log("Button is Pressed by Player / Box");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isPressed = true;

            //Debug.Log("Button still being Pressed by Player / Box");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isPressed = false;

            //Debug.Log("Button is un-Pressed by Player / Box");
        }
    }
}
