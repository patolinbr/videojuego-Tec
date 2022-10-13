using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame ()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void MenuPausa ()
    {
        SceneManager.LoadScene("menu");
    }
}
