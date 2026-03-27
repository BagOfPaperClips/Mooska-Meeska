using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private AudioSource audioSource;
    private AudioClip targetClip;

    [Range(0f, 1f)]
    public float volume = 1f; // adjustable in Inspector or via code

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
        // Fade out from current volume (not forced to 1)
        while(audioSource.volume > 0) {
            audioSource.volume -= Time.deltaTime;
            yield return null;
        }
        audioSource.clip = newClip;
        audioSource.Play();
        audioSource.volume = 0f;
        // Fade in up to the target volume, not always 1
        while(audioSource.volume < volume) {
            audioSource.volume += Time.deltaTime;
            yield return null;
        }
        audioSource.volume = volume; // clamp cleanly
    }
}