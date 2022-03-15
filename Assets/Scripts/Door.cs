using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [Header("States & Attributes")]
    private bool isOpen = false;

    [Header("Reference Stuff")]
    public PlayerController controller;
    public Button[] button;

    public Animator anim;
    public GameObject successText;
    public GameObject doorIsLockText;
    public GameObject missingBoxText;

    private void Awake()
    {
        // Makes sure all text is closed.
        successText.SetActive(false);
        doorIsLockText.SetActive(false);
        missingBoxText.SetActive(false);
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
            if (button[i].isPressed != true)
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
            return;
        }

        if (other.gameObject.CompareTag("Player") && controller.isHolding == true) // check for player tag and that if player is holding a box
        {
            successText.SetActive(true);
            Invoke("LoadScene", 2f);
        }
        else
        {
            missingBoxText.SetActive(true);
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
