using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    [SerializeField] AudioSource mapAudio;
    [SerializeField] Button myButton; 

    private void Start()
    {
        myButton.onClick.AddListener(PlaySound);
    }

    private void PlaySound()
    {
        mapAudio.Play();
    }

    private void OnDestroy()
    {
        myButton.onClick.RemoveListener(PlaySound); 
    }
}
