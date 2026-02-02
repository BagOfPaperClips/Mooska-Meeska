using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.CullingGroup;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance { get; private set;}

    public bool isPaused { get; private set;}

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
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
        }
    }

    public void TogglePause()
    {
        SetPaused(!isPaused);
    }
}
