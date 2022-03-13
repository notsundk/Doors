using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public PlayerController controller;
    public Button[] button;

    public GameObject successText;
    public GameObject missingBoxText;

    private bool isOpen = false;

    private void Update()
    {
        buttonCheck();
    }

    private void buttonCheck()
    {
        isOpen = true;

        for (int i = 0; i < button.Length; i++)
        {
            if (button[i].isPressed != true)
            {
                isOpen = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOpen) // Gaurd Clause
        {
            return;
        }

        if (other.gameObject.CompareTag("Player") && controller.isHolding == true)
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
        missingBoxText.SetActive(false);
    }

    private void LoadScene()
    {
        Debug.Log("Load Next Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
