using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    public void Return2MainMenu()
    {
        Debug.Log("Return to Main Menu");
        SceneManager.LoadScene(0);
    }
}
