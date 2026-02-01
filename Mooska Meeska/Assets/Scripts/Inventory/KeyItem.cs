using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JetBrains.Annotations;
using UnityEngine.UI;
using UnityEditor.UI;
public class KeyItem : MonoBehaviour
{
   [HideInInspector] KeySO key;
   
   [SerializeField] Image image;


    

    public void InitializeKey(KeySO newKey)
    {
        
        if(newKey.icon != null)
        {
            Debug.Log("never gonna give you up");
            image.sprite = newKey.icon;
        }
        
    }
}
