using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMechanics : MonoBehaviour
{
    [SerializeField] public GameObject HelpGO;
    [SerializeField] public GameObject ExitGO;

    private void Awake()
    {
        if (HelpGO != null)
        {
            HelpGO.SetActive(false);
        }
    }
    public void Resume()
    {
        if (PauseManager.instance == null)
        {
            return;
        }

        PauseManager.instance.SetPaused(false);

        PauseManager.instance.ShowPauseScreen(false);

        if (HelpGO != null)
        {
            HelpGO.SetActive(false);
        }
    }

    public void Help()
    {
        if (PauseManager.instance == null)
        {
            return;
        }

        PauseManager.instance.SetPaused(true);

        if (HelpGO != null)
        {
            HelpGO.SetActive(true);
        }

        gameObject.SetActive(false);
    }

    public void BackSettings()
    {
        gameObject.SetActive(true);

        if (PauseManager.instance == null)
        {
            return;
        }

        PauseManager.instance.SetPaused(true);

        if (HelpGO != null)
        {
            HelpGO.SetActive(false);
        }
    }

    public void Exit()
    {
        if (PauseManager.instance == null)
        {
            return;
        }

        PauseManager.instance.SetPaused(true);

        if (ExitGO != null)
        {
            ExitGO.SetActive(true);
        }

        gameObject.SetActive(false);
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Title");
    }

    public void Quit()
    {
        Application.Quit();
    }
}