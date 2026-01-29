using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/KeySO")]

public class KeySO : ScriptableObject
{
    public string color;
    public Sprite icon;
    public GameObject key;
}
