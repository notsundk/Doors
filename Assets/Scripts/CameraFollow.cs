using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("States & Attributes")]
    public float cameraSpeed = 1;
    public int rotationAmount = 360;
    public int spinSpeed = 1;
    private bool Once = false;

    [Header("Reference Stuff")]
    public Transform TargetPos;

    IEnumerator CameraSpin()
    {
        //for (int i = 0; i <= 360; i++)
        //{
        //    gameObject.transform.rotation = Quaternion.Euler(0, 0, i);
        //    yield return null;
        //}

        for (int i = rotationAmount; i >= 0; i -= spinSpeed)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, i);
            yield return null;
        }

        Once = true;
    }

    void Update()
    {
        if (!Once)
        {
            StartCoroutine(CameraSpin());
        }

        Vector3 Player = new Vector3(TargetPos.position.x, TargetPos.position.y, -10);
        transform.position = Vector3.MoveTowards(transform.position, Player, cameraSpeed * Time.deltaTime);
    }
}
