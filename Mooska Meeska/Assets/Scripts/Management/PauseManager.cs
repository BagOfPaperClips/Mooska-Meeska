using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class PauseManager : MonoBehaviour
{
    [Header ("Pause Menu")]
    [SerializeField] private GameObject PauseScreen;
    [SerializeField] private GameObject SettingScreen;
    [SerializeField] private GameObject ExitScreen;

    [Header("Sounds(s)")]
    [SerializeField] private AudioSource audioSource;

    private PauseMechanics pauseMechanics;
    private MouseLook mouseLook;
    private BirdBookManager birdBookManager;
    private SceneLoader sceneLoader;
    

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

        isPaused = true;
        Time.timeScale = 1.0f;

        pauseMechanics = FindFirstObjectByType<PauseMechanics>();
        mouseLook = FindFirstObjectByType<MouseLook>();
        birdBookManager = FindFirstObjectByType<BirdBookManager>();
        sceneLoader = FindFirstObjectByType<SceneLoader>();
    }

    public void ForcePauseShow (bool show)
    {
        if (PauseScreen != null)
        {
            PauseScreen.SetActive(show);
        }

        if (!show)
        {
            if (SettingScreen != null)
            {
                SettingScreen.SetActive(false);
            }

            if (ExitScreen != null)
            {
                ExitScreen.SetActive(false);
            }
        }
    }

    public void SetPaused(bool paused)
    {
        isPaused = paused;

        if (paused)
        {
            Time.timeScale = 0f;

            if (audioSource != null)
            {
                audioSource.Pause();
            }
        }

        else
        {
            Time.timeScale = 1f;

            if (audioSource != null)
            {
                audioSource.Play();
            }

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
            if (pauseMechanics != null && pauseMechanics.HelpGO != null)
            {
                pauseMechanics.HelpGO.SetActive(false);
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

        if (birdBookManager != null)
        {
            if (birdBookManager.isOpen)
            {
                return;
            }
        }

        if (pauseMechanics != null && pauseMechanics.HelpGO != null)
        {
            if (pauseMechanics.HelpGO.activeInHierarchy)
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
            if (pauseMechanics != null && pauseMechanics.HelpGO != null)
            {
                pauseMechanics.HelpGO.SetActive(false);
            }
        }
    }
}
