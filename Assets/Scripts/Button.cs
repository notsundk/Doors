using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("States & Attributes")]
    public bool isPressed = false;

    [Header("Reference Stuff")]
    public Animator anim;

    [Header("Auto-Reference Stuff")]
    public GameObject Sound_Button_Pressed;

    void Start()
    {
        anim = GetComponent<Animator>();

        Sound_Button_Pressed = GameObject.Find("Sound_Button_Pressed");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isPressed = true;
            anim.SetBool("isPressed", true);

            Sound_Button_Pressed.GetComponent<AudioSource>().Play();

            Debug.Log("Button is Pressed by Player / Box");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isPressed = true;
            anim.SetBool("isPressed", true);

            //Debug.Log("Button still being Pressed by Player / Box");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isPressed = false;
            anim.SetBool("isPressed", false);

            Debug.Log("Button is un-Pressed by Player / Box");
        }
    }
}
