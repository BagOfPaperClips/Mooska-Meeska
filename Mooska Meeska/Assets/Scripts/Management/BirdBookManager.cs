using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBookManager : MonoBehaviour
{
    [Header("Book UI")]
    [SerializeField] private GameObject birdBookUI;

    [Header("DEBUG")]
    [SerializeField] private float WaitTime = 0.5f;

    private bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;

        if (birdBookUI == null)
        {
            birdBookUI = GameObject.FindWithTag("Bird Book");
        }
        birdBookUI.SetActive(true);

        StartCoroutine(WaitToDeactivate(WaitTime));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            ToggleBook();
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            birdBookUI.SetActive(false);
            isOpen = false;
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

    IEnumerator WaitToDeactivate(float wait)
    {
        Debug.Log("Waiting");
        yield return new WaitForSecondsRealtime(wait);
        Debug.Log("Done Waiting");

        birdBookUI.SetActive(false);

    }
}
