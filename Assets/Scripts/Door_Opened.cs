using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Opened : MonoBehaviour
{
    public PlayerController controller;
    public GameObject successText;
    public GameObject missingBoxText;

    private void OnTriggerEnter2D(Collider2D other)
    {
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
