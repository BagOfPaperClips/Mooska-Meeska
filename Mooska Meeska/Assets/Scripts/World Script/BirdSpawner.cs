using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{

public GameObject defaultBirdPrefab; 
public Transform bird;
public TrackSun mouse;
public List<GameObject> birds;

float timer = 0f;
float timerInterval = 2f;

int lastInactive = 0;

//Instantiate bird model if firstBird is not "found"
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    if (timer >= timerInterval)
    {
        lastInactive = ToggleBird(lastInactive);
        timer = 0f;
    }
       //if bird catches mouse, hostile = true, timer starts, animation starts
       //if hidden = true, timer ends and hostile = false
       //else if (timer = 0) kill mouse 
    }

    public int ToggleBird(int active) { 
        if (active == 0) {
            Debug.Log("currently no inactive birds");
        }
        else {
            Debug.Log("Current inactive bird: " + active);
        }
            Debug.Log("Num of birds" + birds.Count);

        if (active == 0) {
        active = Random.Range(1, birds.Count + 1);
        }
        birds[active - 1].SetActive(true);
        int inactive = Random.Range(1, birds.Count + 1);
        while (inactive  == active) {
            inactive = Random.Range(1, birds.Count + 1);
        }
                Debug.Log("New inactive bird = : " + inactive);

        birds[inactive -1].SetActive(false);
        return inactive;

    }

    public void InstantiateBird(BirdSO birdName, int x, int y) {    
        //instantiate 

    }

    // public void RefreshBirds() {
    //     for (int i = 0; i < birds.Count; i++) {
    //         if (birds[i].found) InstantiateBird(birds[i], 0, 0);
    //     }
    // }
}
