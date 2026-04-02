using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip[] sounds;
    public float minInterval = 2f;
    public float maxInterval = 5f;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomLoop());
    }

    IEnumerator PlayRandomLoop()
    {
        while (true)
        {
            source.clip = sounds[Random.Range(0, sounds.Length)];
            source.Play();
            yield return new WaitForSeconds(source.clip.length + Random.Range(minInterval, maxInterval));
        }
    }
}