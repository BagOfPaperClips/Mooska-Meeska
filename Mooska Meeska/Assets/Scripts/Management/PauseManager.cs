using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject SettingScreen;
    [SerializeField] private GameObject ExitScreen;

    private PauseMechanics pauseMechanics;
    private MouseLook mouseLook;

    public static PauseManager instance { get; private set; }

    public bool isPaused { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        if (PauseScreen != null)
        {
            PauseScreen.SetActive(false);
        }

        if (SettingScreen != null)
        {
            SettingScreen.SetActive(false);
        }

        if (ExitScreen != null)
        {
            ExitScreen.SetActive(false);
        }

        isPaused = false;
        Time.timeScale = 1.0f;

        pauseMechanics = FindFirstObjectByType<PauseMechanics>();
        mouseLook = FindFirstObjectByType<MouseLook>();
    }

    public void SetPaused(bool paused)
    {
        isPaused = paused;

        if (paused)
        {
            Time.timeScale = 0f;
        }

        else
        {
            Time.timeScale = 1f;
            ShowPauseScreen(false);
        }
    }

    public void TogglePause()
    {
        bool Paused = !isPaused;

        SetPaused(Paused);
        ShowPauseScreen(Paused);

        if (!Paused)
        {
            if (pauseMechanics != null && pauseMechanics.SettingsGO != null)
            {
                pauseMechanics.SettingsGO.SetActive(false);
            }
        }
    }

    public void ShowPauseScreen(bool paused)
    {
        if (PauseScreen == null)
        {
            return;
        }

        if (PauseScreen != null)
        {

            if (paused)
            {
                mouseLook.UnlockCursor();
            }

            else
            {
                mouseLook.LockCursor();
            }
        }
        PauseScreen.SetActive(paused);
        SettingScreen.SetActive(false);
        ExitScreen.SetActive(false);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape))
        {
            return;
        }

        if (pauseMechanics != null && pauseMechanics.SettingsGO != null)
        {
            if (pauseMechanics.SettingsGO.activeInHierarchy)
            {
                pauseMechanics.BackSettings();

                SetPaused(true);
                ShowPauseScreen(true);

                return;
            }
        }

        TogglePause();

        if (isPaused)
        {
            if (pauseMechanics != null && pauseMechanics.SettingsGO != null)
            {
                pauseMechanics.SettingsGO.SetActive(false);
            }
        }
    }

}