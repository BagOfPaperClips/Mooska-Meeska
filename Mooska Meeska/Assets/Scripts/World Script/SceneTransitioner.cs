using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransitioner : MonoBehaviour
{
    public void Title()
    {
        SceneManager.LoadScene("Title");
    }
    public void Game()
    {
        SceneManager.LoadScene("Game");
    }
    public void Help()
    {
        SceneManager.LoadScene("Help");
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Death()
    {
        SceneManager.LoadScene("Death");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
