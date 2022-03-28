using UnityEngine;

public class Barrier : MonoBehaviour
{
    [Header("States & Attributes")]
    public float moveSpeed = 1;
    private bool playSound = false;
    private bool playedSound = false;

    [Header("Reference Other Scripts")]
    public Button[] button;

    [Header("Reference Stuff")]
    public GameObject barrier;
    public Transform movePoint;
    public Transform originalPos;

    [Header("Auto-Reference Stuff")]
    public GameObject Sound_Barrier_Whoosh;

    private void Start()
    {
        originalPos.parent = null;
        movePoint.parent = null;
        originalPos.position = barrier.transform.position;

        Sound_Barrier_Whoosh = GameObject.Find("Sound_Barrier_Whoosh");
    }

    private void Update()
    {
        Debug.Log("Barrier originalPos: " + originalPos.position);
        buttonCheck();
        Whoosh();
    }

    private void buttonCheck()
    {
        for (int i = 0; i < button.Length; i++)
        {
            if (!button[i].isPressed)
            {
                barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, originalPos.position, moveSpeed * Time.deltaTime);
                playedSound = false;
                return;
            }
        }

        playSound = true;
        barrier.transform.position = Vector3.MoveTowards(barrier.transform.position, movePoint.position, moveSpeed * Time.deltaTime);
    }

    private void Whoosh()
    {
        if (playSound && !playedSound)
        {
            Sound_Barrier_Whoosh.GetComponent<AudioSource>().Play();
            playSound = false;
            playedSound = true;
        }
    }
}
