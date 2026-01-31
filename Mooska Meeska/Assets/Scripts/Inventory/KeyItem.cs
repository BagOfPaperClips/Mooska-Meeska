using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEditor.UI;
public class KeyItem : MonoBehaviour
{
   [SerializeField] KeySO key;
   
   [SerializeField] Image image;


    private void Start()
    {
        InitializeKey(key);
    }

    public void InitializeKey(KeySO newKey)
    {
        
        if(newKey.icon != null)
        {
            Debug.Log("never gonna give you up");
            image.sprite = newKey.icon;
        }
        
    }
}
