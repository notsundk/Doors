using UnityEngine;

public class Box : MonoBehaviour
{
    [Header("Reference Stuff")]
    private PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Player"))  // Guard Clause
        {
            return;
        }

        controller.boxClass = this; // Make sure it reference the correct box

        Debug.Log("Box Collided with Player");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))  // Guard Clause
        {
            return;
        }

        controller.boxClass = this;

        //Debug.Log("Box Still Collided with Player");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))  // Guard Clause
        {
            return;
        }

        controller.boxClass = null; // Make sure it un-reference the correct box

        Debug.Log("Box Un-Collided with Player");
    }
}
