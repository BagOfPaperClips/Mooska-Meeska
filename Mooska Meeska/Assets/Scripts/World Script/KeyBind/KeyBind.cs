using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class KeyBind : MonoBehaviour
{
    [Header("UI Text")]
    [SerializeField] private TextMeshProUGUI KeyBindText;

    [Header("Bind")]
    [SerializeField] private GameKeys KeyBindName = GameKeys.Interact;
    [SerializeField] private KeyCode defaultKey = KeyCode.E;

    private bool Listening;
    private Color originalColor;
    private KeyCode boundKey;

    private void Awake()
    {
        if (KeyBindText == null)
        {
            KeyBindText = GetComponentInChildren<TextMeshProUGUI>();
        }

        boundKey = KeyBinding.GetKey(KeyBindName, defaultKey);

        if (KeyBindText != null)
        {
            originalColor = KeyBindText.color;
            KeyBindText.text = boundKey.ToString();
        }

        Listening = false;
    }

    private void Update()
    {
        if (!Listening)
        {
            return;
        }

        if (!Input.anyKeyDown)
        {
            return;
        }

        KeyCode pressed = GetPressedKey();

        if (pressed == KeyCode.None)
        {
            return;
        }

        boundKey = pressed;
        KeyBinding.SetKey(KeyBindName, boundKey);

        if (KeyBindText != null)
        {
            KeyBindText.color = originalColor;
            KeyBindText.text = boundKey.ToString();
        }

        Listening = false;
    }

    public void ChangeKey()
    {
        Listening = true;

        if (KeyBindText != null)
        {
            KeyBindText.color = Color.red;
            KeyBindText.text = "Key";
        }
    }

    public KeyCode GetKey()
    {
        return boundKey;
    }

    private KeyCode GetPressedKey()
    {
        Array values = Enum.GetValues(typeof(KeyCode));

        for (int i = 0; i < values.Length; i++)
        {
            KeyCode key = (KeyCode)values.GetValue(i);

            if (Input.GetKeyDown(key))
            {
                return key;
            }
        }



        return KeyCode.None; 
    }

    public void Default()
    {
        boundKey = defaultKey;

        KeyBinding.SetKey(KeyBindName, boundKey);

        if (KeyBindText != null)
        {
            KeyBindText.color = originalColor;
            KeyBindText.text = boundKey.ToString();
        }

        Listening = false;
    }
}

public enum GameKeys
{
    Interact,
    OpenBook,
    PageLeft,
    PageRight
}
