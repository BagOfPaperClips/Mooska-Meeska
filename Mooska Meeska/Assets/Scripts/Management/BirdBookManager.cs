using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class BirdBookManager : MonoBehaviour
{
    [Header("Book UI")]
    [SerializeField] private GameObject birdBookUI;

    [Header("References")]
    [SerializeField] private GameObject Instructions;
    [SerializeField] private GameObject[] PauseMenu;

    [Header("Camera")]
    [SerializeField] private CinemachineFreeLook freeLookCamera;

    public bool isOpen { private set; get; }
    private SceneLoader sceneLoader;
    private PauseManager pauseManager;
    private MouseLook mouseLook;

    private KeyCode openBookKey;

    private float defaultXSpeed;
    private float defaultYSpeed;

    private void Awake()
    {
        if (sceneLoader == null)
        {
            sceneLoader = FindFirstObjectByType<SceneLoader>();

            if (sceneLoader == null)
            {
                Debug.Log("No SceneLoaders present in scene");
            }
        }

        if (freeLookCamera != null)
        {
            defaultXSpeed = freeLookCamera.m_XAxis.m_MaxSpeed;
            defaultYSpeed = freeLookCamera.m_YAxis.m_MaxSpeed;
        }

        pauseManager = FindFirstObjectByType<PauseManager>();
        mouseLook = FindFirstObjectByType<MouseLook>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;

        if (birdBookUI != null)
        {
            birdBookUI.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Instructions == null)
        {
            return;
        }

        if (!Instructions.activeSelf)
        {
            openBookKey = KeyBinding.GetKey(GameKeys.OpenBook, KeyCode.Q);
            if (Input.GetKeyUp(openBookKey) && !pauseManager.isPaused)
            {
                ToggleBook();
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                birdBookUI.SetActive(false);
                isOpen = false;
                mouseLook.LockCursor();
                SetCameraMovement(true);
            }
        }

        if (PauseMenuActive())
        {
            if (isOpen)
            {
                birdBookUI.SetActive(false);
                isOpen = false;
            }
            return;
        }
    }

    public void ForceShow(bool open)
    {
        isOpen = open; 

        if (birdBookUI != null)
        {
            birdBookUI.SetActive(open);
        }
    }

    public void ToggleBook()
    {
        if (birdBookUI == null)
        {
            return;
        }
        

        isOpen = !isOpen;
        birdBookUI.SetActive(isOpen);

        if (isOpen)
        {
            mouseLook.UnlockCursor();
            SetCameraMovement(false);
        }

        else
        {
            mouseLook.LockCursor();
            SetCameraMovement(true);
        }

        //if (PauseManager.instance != null)
        //{
        //    PauseManager.instance.SetPaused(isOpen);
        //}
    }

    private bool PauseMenuActive()
    {
        if (PauseMenu == null)
        {
            return false;
        }

        for (int i = 0; i < PauseMenu.Length; i++)
        {
            if (PauseMenu[i] != null)
            {
                if (PauseMenu[i].activeInHierarchy)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void SetCameraMovement(bool canMove)
    {
        if (freeLookCamera == null)
        {
            return;
        }

        if (canMove)
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = defaultXSpeed;
            freeLookCamera.m_YAxis.m_MaxSpeed = defaultYSpeed;
        }

        else
        {
            freeLookCamera.m_XAxis.m_MaxSpeed = 0f;
            freeLookCamera.m_YAxis.m_MaxSpeed = 0f;
        }
    }
}
