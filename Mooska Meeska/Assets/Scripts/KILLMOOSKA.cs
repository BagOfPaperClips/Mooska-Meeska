using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KILLMOOSKA : MonoBehaviour
{
    //guys for some reason on my computer i couldn't get the click on the back button from the death scene to work so this is a throwaway script in case it happens during playtesting

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
        SceneManager.LoadScene("Title");
        }
    }
}
