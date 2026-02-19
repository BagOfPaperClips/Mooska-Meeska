using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinder : MonoBehaviour
{
    public static KeyCode InteractKey => KeyBinding.GetKey(GameKeys.Interact, KeyCode.E);
}
