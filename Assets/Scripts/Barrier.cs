using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header("States & Attributes")]
    public float moveSpeed = 1;

    [Header("Reference Other Scripts")]
    public Button[] button;

    [Header("Reference Stuff")]
    public GameObject barrier;
    public Transform movePoint;
    public Transform originalPos;

    private void Start()
    {
        originalPos.parent = null;
        movePoint.parent = null;
        originalPos.position = barrier.transform.position;
    }

    private void Update()
    {
        Debug.Log("Barrier originalPos: " + originalPos.position);
        buttonCheck();
    }

    private void buttonCheck()
    {
        for (int i = 0; i < button.Length; i++)
        {
            if (!button[i].isPressed)
            {
                barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, originalPos.position, moveSpeed * Time.deltaTime);
                return;
            }
        }

        barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }
}
