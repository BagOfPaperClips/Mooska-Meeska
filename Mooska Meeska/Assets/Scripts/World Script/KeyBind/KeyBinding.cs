using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyBinding
{
    private const string Prefix = "bind_";

    public static KeyCode GetKey(GameKeys action, KeyCode defaultKey)
    {
        string prefKey = Prefix + action.ToString();

        if (PlayerPrefs.HasKey(prefKey))
        {
            int saved = PlayerPrefs.GetInt(prefKey);

            return (KeyCode)saved;
        }
        return defaultKey;
    }

    public static void SetKey(GameKeys action, KeyCode Key)
    {
        string prefKey = Prefix + action.ToString();


        PlayerPrefs.SetInt(prefKey, (int) Key);

        PlayerPrefs.Save();
    }

    public static void ClearKey(GameKeys action)
    {
        string prefKey = Prefix + action.ToString();

        if (PlayerPrefs.HasKey(prefKey))
        {
            PlayerPrefs.DeleteKey(prefKey);

            PlayerPrefs.Save();
        }
    }
}
