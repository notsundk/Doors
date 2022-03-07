using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference Video: https://youtu.be/mbzXIOKZurA

    public float moveSpeed = 5f;
    public Transform movePoint;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;    // movePoint child won't have parent any more.
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime); // Vector3.MoveTowards(current position, target position, max distance delta?)

        // "Horizontal" && "Vertical" string used below are from Unity's

        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) // Button Check Horizontal // Get Raw Axis for Horizontal Input, use absolute on it so that it is "1" no matter what, then check if it is equal to "1".
        {
            movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) // Button Check Vertical
        {
            movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
        }
    }
}
