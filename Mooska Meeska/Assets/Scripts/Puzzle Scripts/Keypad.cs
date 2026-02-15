using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Data.Common;

public class Keypad : MonoBehaviour
{
   
   public TextMeshProUGUI texty;
   public string answer = "1234";
   public Keypad keypad;
   public GameObject player;
   private MouseLook mouseLook;

   void Awake()
    {
        mouseLook = FindFirstObjectByType<MouseLook>();
    }

    void Update()
    {
        if (keypad.gameObject.activeInHierarchy)
        {
            mouseLook.UnlockCursor();
        }
    }



    public void OnEnable()
    {
        player.GetComponent<Movement>().enabled = false;
        
    }

    public void Number(int number)
    {
        texty.text += number.ToString();
    }

    public void Execute()
    {
        if(texty.text == answer)
        {
            texty.text = "Correct";
        }
        else
        {
            texty.text = "Wrong";
        }
    }

    public void Clear()
    {
        texty.text = "";
    }

    public void Exit()
    {
        player.GetComponent<Movement>().enabled = true;
        mouseLook.LockCursor();
        keypad.gameObject.SetActive(false);
    }
}
