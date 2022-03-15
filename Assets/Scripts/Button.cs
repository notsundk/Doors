using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("States & Attributes")]
    public bool isPressed = false;

    [Header("Reference Stuff")]
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Box"))
        {
            isPressed = true;
            anim.SetBool("isPressed", true);

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
