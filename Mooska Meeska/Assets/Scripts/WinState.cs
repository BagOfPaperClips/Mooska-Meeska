using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : MonoBehaviour
{
    private MouseLook mouseLook;
    // Start is called before the first frame update
    void Start()
    {
        mouseLook = FindFirstObjectByType<MouseLook>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Meeska"))
        {
            Debug.Log("wait for it");
            mouseLook.enabled = false;
            mouseLook.UnlockCursor();
            SceneManager.LoadScene("Win");
        }

    }
}
