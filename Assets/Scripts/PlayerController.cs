using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Reference Video:
    // Grid Based Movement in Unity: https://youtu.be/mbzXIOKZurA

    // Don't forget to reference!!!
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    public Animator anim;

    /////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;    // movePoint child won't have parent any more.
                                    // Why? idk.
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Position: " + transform.position);
        Debug.Log("Target Position: " + movePoint.position);

        transform.position = Vector3.MoveTowards(/*current pos*/transform.position, /*target pos*/movePoint.position, /*max distance delta*/moveSpeed * Time.deltaTime); 

        if(Vector3.Distance(transform.position, movePoint.position) <= .05f) // Check for distance between "current pos" and "target pos", checks if it's <= .05f
        {
            // "Horizontal" && "Vertical" string used below are from Unity's
            // Get Raw Axis for Horizontal Input, use absolute on it so that it is "1" no matter what, then check if it is equal to "1".
            // Use "else if" to combine the 2 Button Checks if you don't want the player to walk diagonally.

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) // Button Check Horizontal 
            {
                // Checks for Colliders
                if(!Physics2D.OverlapCircle(/*vector*/movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f),/*circle radius*/.2f, /*layer mask*/whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) // Button Check Vertical
            {
                // Checks for Colliders
                if (!Physics2D.OverlapCircle(/*vector*/movePoint.position + new Vector3(Input.GetAxisRaw("Vertical"), 0f, 0f),/*circle radius*/.2f, /*layer mask*/whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }

            anim.SetBool("Moving", false); 
        }
        else
        {
            anim.SetBool("Idle", true);
        }
    }
}
