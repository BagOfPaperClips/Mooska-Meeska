using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private bool locked = false;
    private BirdBookManager birdBookManager;

    private void Awake()
    {
        birdBookManager = FindFirstObjectByType<BirdBookManager>();
    }

    private void Start()
    {
        locked = false;
        LockCursor();
    }

    void Update()
    {
        bool lockin = false;

        if (PauseManager.instance != null)
        {
            if (PauseManager.instance.isPaused)
            {
                lockin = true;
            }
        }

        if (birdBookManager != null)
        {
            if (birdBookManager.isOpen)
            {
                lockin = true;
            }
        }

        if (lockin)
        {
            if (locked)
            {
                UnlockCursor();
            }
        }

        else
        {
            if (!locked)
            {
                LockCursor();
            }
        }
    }

    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        locked = true;
    }

    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        locked = false;
    }
}