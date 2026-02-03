using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMechanics : MonoBehaviour
{
    [SerializeField] public GameObject SettingsGO;
    [SerializeField] public GameObject ExitGO;

    private void Awake()
    {
        if (SettingsGO != null)
        {
            SettingsGO.SetActive(false);
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

        if (SettingsGO != null)
        {
            SettingsGO.SetActive(false);
        }
    }

    public void Settings()
    {
        if (PauseManager.instance == null)
        {
            return;
        }

        PauseManager.instance.SetPaused(true);

        if (SettingsGO != null)
        {
            SettingsGO.SetActive(true);
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

        if (SettingsGO != null)
        {
            SettingsGO.SetActive(false);
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