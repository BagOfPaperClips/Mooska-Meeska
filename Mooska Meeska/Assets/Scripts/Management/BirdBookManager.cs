using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBookManager : MonoBehaviour
{
    [Header("Book UI")]
    [SerializeField] private GameObject birdBookUI;

    [Header("References")]
    [SerializeField] private GameObject Instructions;
    [SerializeField] private GameObject[] PauseMenu;


    public bool isOpen { private set; get; }
    private SceneLoader sceneLoader;
    private PauseManager pauseManager;

    private KeyCode openBookKey;

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

        pauseManager = FindFirstObjectByType<PauseManager>();
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
            if (Input.GetKeyUp(openBookKey))
            {
                ToggleBook();
            }

            if (Input.GetKeyUp(KeyCode.Escape))
            {
                birdBookUI.SetActive(false);
                isOpen = false;
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
}
