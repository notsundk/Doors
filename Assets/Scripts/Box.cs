using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private PlayerController controller;
    private bool playerOnTop = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerOnTop == true)
        {
            controller.isHolding = true;
            Debug.Log("Player Holding Box, Destroy gameObject");
            Destroy(gameObject); // small g gameObject is refering to itself
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.gameObject.CompareTag("Player"))  // Guard Clause
        {
            return;
        }

        playerOnTop = true;

        Debug.Log("Box Collided with Player");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))  // Guard Clause
        {
            return;
        }

        playerOnTop = false;

        Debug.Log("Box Un-Collided with Player");
    }
}
