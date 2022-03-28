using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [Header("States & Attributes")]
    private bool isOpen = false;

    [Header("Reference Other Scripts")]
    private PlayerController controller;
    public Button[] button;

    [Header("Reference Stuff")]
    public Animator anim;
    public GameObject successText;
    public GameObject doorIsLockText;
    public GameObject missingBoxText;

    [Header("Auto-Reference Stuff")]
    public GameObject Sound_Door_Locked;
    public GameObject Sound_Door_MissingBox;
    public GameObject Sound_Door_Success;

    private void Awake()
    {
        controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();   // Auto Reference

        successText.SetActive(false);
        doorIsLockText.SetActive(false);
        missingBoxText.SetActive(false);

        Sound_Door_Locked = GameObject.Find("Sound_Door_Locked");
        Sound_Door_MissingBox = GameObject.Find("Sound_Door_MissingBox");
        Sound_Door_Success = GameObject.Find("Sound_Door_Success");
    }

    private void Update()
    {
        buttonCheck();
    }

    private void buttonCheck() // Check if all button in array is being pressed.
    {
        isOpen = true;
        anim.SetBool("isOpen", true);

        for (int i = 0; i < button.Length; i++)
        {
            //if (button[i].isPressed == false)
            //if (button[i].isPressed != true)
            if (!button[i].isPressed)
            {
                isOpen = false;
                anim.SetBool("isOpen", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // On entering the door
    {
        if (!isOpen) // Gaurd Clause, return if door is not opened
        {
            doorIsLockText.SetActive(true);
            Sound_Door_Locked.GetComponent<AudioSource>().Play();
            return;
        }

        if (other.gameObject.CompareTag("Player") && controller.isHolding == true) // check for player tag and that if player is holding a box
        {
            successText.SetActive(true);
            Sound_Door_Success.GetComponent<AudioSource>().Play();
            Invoke("LoadScene", 2f);
        }
        else
        {
            missingBoxText.SetActive(true);
            Sound_Door_MissingBox.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        doorIsLockText.SetActive(false);
        missingBoxText.SetActive(false);
    }

    private void LoadScene()
    {
        Debug.Log("Load Next Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
