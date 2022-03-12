using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    //[SerializeField] GameObject activeTarget;

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    activeTarget.SetActive(false);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    activeTarget.SetActive(true);
    //}
}
