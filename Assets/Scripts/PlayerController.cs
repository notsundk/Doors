using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{  
    // Notes:
    // small g gameObject is refering to itself.
    // "If statements" are always comparing to "true" (bool).
    // "Horizontal" && "Vertical" string used below are from Unity's.
    // Get Raw Axis for Horizontal Input, use absolute on it so that it is "1" no matter what, then check if it is equal to "1".

    // Champs Quotes:
    // Know what you're writing.

    // Reference Video:
    // Grid Based Movement in Unity: https://youtu.be/mbzXIOKZurA
    // Sprite Sorting Layer: https://youtu.be/9vBbg1-Bxcw

    [Header("States & Attributes")]
    [Tooltip("Player's Move Speed, this affect Distance as well for some reason.")]
    public float moveSpeed = 5f;
    public bool isWalking = false;
    public bool isHolding = false;

    [Header("Reference Stuff")]
    public Transform movePoint;
    public Animator anim;
    [Tooltip("Prefab of Box, for placement as Clone")]
    public GameObject boxPrefab;
    [Tooltip("Class of the held Box GameObject")]
    public Box boxClass;

    [Header("Collision Layer Selection")]
    [Tooltip("Only the Collision in that selected LayerMask will affect the Player.")]
    public LayerMask whatStopsMovement;

    [Header("Gizmo Control")]
    [SerializeField] private float radius = .2f;

    /////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;    // movePoint child won't have parent no more.
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        BoxHoldingAndPlacement();
        QuickRestart();
        LevelSkip();
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
        if (Input.GetKeyDown(KeyCode.Space)) // Press Space
        {
            if (isHolding == false && boxClass != null) // Pick up box, if player: is not holding box & doesn't detect a boxClass
            {
                isHolding = true;
                anim.SetBool("isCarrying", true);
                Destroy(boxClass.gameObject);   // It's okay to destroy boxClass because new box is generated from Prefab
                boxClass = null;

                //Debug.Log("Player Pick up Box, Destroy gameObject");
            }
            else if (isHolding == true && isWalking == false && boxClass == null) // Put down box, if player: is holding box & is not walking & doesn't have a boxClass
            {
                isHolding = false;
                anim.SetBool("isCarrying", false);
                GameObject temp = Instantiate(boxPrefab); // Instantiate box (prefab) called "temp"
                temp.transform.position = this.transform.position + new Vector3(0, -0.1f, 0); // Setting Offset to temp  

                //Debug.Log("Player Put down Box, Instantiate gameObject");
            }
        }
    }

    private void QuickRestart()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Quick Restart");
        }
    }

    private void LevelSkip()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Level Skip");
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireCube(movePoint.position, new Vector2(x, y));
        Gizmos.DrawWireSphere(movePoint.position, radius);
    }
}
