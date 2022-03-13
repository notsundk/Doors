using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Notes:
    // small g gameObject is refering to itself
    // "If statements" are always comparing to "true" (bool)
    // "Horizontal" && "Vertical" string used below are from Unity's
    // Get Raw Axis for Horizontal Input, use absolute on it so that it is "1" no matter what, then check if it is equal to "1".

    // Reference Video:
    // Grid Based Movement in Unity: https://youtu.be/mbzXIOKZurA
    // Sprite Sorting Layer: https://youtu.be/9vBbg1-Bxcw

    // Don't forget to reference!!!
    public float moveSpeed = 5f;
    public bool isWalking = false;
    public bool isHolding = false;

    public Transform movePoint;
    public Animator anim;
    public GameObject box;
    public Box boxClass;

    public GameObject movePointChecker;

    public LayerMask whatStopsMovement;

    // Gizmos
    //[SerializeField] private float x = 1;
    //[SerializeField] private float y = 1;
    [SerializeField] private float radius = .2f;

    /////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;    // movePoint child won't have parent any more.
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        BoxHoldingAndPlacement();
    }

    private void Movement()
    {
        //Debug.Log("Target Position: " + movePoint.position);

        transform.position = Vector3.MoveTowards(/*current pos*/transform.position, /*target pos*/movePoint.position, /*max distance delta*/moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= .05f) // Check for distance between "current pos" and "target pos", checks if it's <= .05f
        {
            anim.SetBool("isWalking", false);
            isWalking = false;

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f) // Button Check Horizontal 
            {
                // Checks for Colliders
                if (!Physics2D.OverlapCircle(/*vector*/movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f),/*circle radius*/ radius, /*layer mask*/whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                    anim.SetBool("isWalking", true);
                    isWalking = true;
                }
            }

            // Use "else if" to combine the 2 Button Checks if you don't want the player to walk diagonally (do at a time).

            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f) // Button Check Vertical
            {
                // Checks for Colliders
                if (!Physics2D.OverlapCircle(/*vector*/movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f),/*circle radius*/ radius, /*layer mask*/whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                    anim.SetBool("isWalking", true);
                    isWalking = true;
                }
            }
        }
    }

    private void BoxHoldingAndPlacement()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isHolding == false && boxClass != null) // Pick up box
            {
                isHolding = true;
                anim.SetBool("isCarrying", true);

                Debug.Log("Player Pick up Box, Destroy gameObject");

                Destroy(boxClass.gameObject);
                boxClass = null;
            }
            else if (isHolding == true && isWalking == false && boxClass == null) // Put down box
            {
                isHolding = false;
                anim.SetBool("isCarrying", false);

                Debug.Log("Player Put down Box, Instantiate gameObject");

                GameObject temp = Instantiate(box); // Instantiate box (prefab) called "temp"
                temp.transform.position = this.transform.position + new Vector3(0, -0.1f, 0); // Setting Offset to temp  
            }
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(movePoint.position, new Vector2(x, y));
        Gizmos.DrawWireSphere(movePoint.position, radius);
    }
}
