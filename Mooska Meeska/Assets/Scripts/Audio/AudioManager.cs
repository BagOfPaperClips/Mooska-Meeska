using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip targetClip;

    void Start () {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void ChangeBGM(AudioClip newClip) {
        if(targetClip == newClip) return;
        targetClip = newClip;
        StopAllCoroutines();
        StartCoroutine(Fade(newClip));
    }

    IEnumerator Fade(AudioClip newClip) {
        audioSource.volume = 1f;
        while(audioSource.volume > 0) {
            audioSource.volume -= Time.deltaTime;
            yield return null;
        }
        audioSource.clip = newClip;
        audioSource.Play();
        audioSource.volume = 0f;
        while(audioSource.volume < 1) {
            audioSource.volume += Time.deltaTime;
            yield return null;
        }
    }
}