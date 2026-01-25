using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBookManager : MonoBehaviour
{
    [Header("Book UI")]
    [SerializeField] private GameObject birdBookUI;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;

        if (birdBookUI != null)
        {
            birdBookUI.SetActive(false);
        }

        else if (birdBookUI == null)
        {
            birdBookUI = GameObject.FindWithTag("Bird Book");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            ToggleBook();
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

        if (PauseManager.instance != null)
        {
            PauseManager.instance.SetPaused(isOpen);
        }

        if (isOpen)
        {
            //IF PLAYERS ARE GOING TO USE KEYS TO NAVIGATE THROUGH THE BOOK THEN UNCOMMENT THE BELOW
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;
        }
    }
}
