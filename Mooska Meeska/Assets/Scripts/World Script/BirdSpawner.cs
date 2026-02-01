using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{

public GameObject defaultBirdPrefab; 
public Transform bird;
public TrackSun mouse;
public List<BirdSO> birds;

//Instantiate bird model if firstBird is not "found"
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //if bird catches mouse, hostile = true, timer starts, animation starts
       //if hidden = true, timer ends and hostile = false
       //else if (timer = 0) kill mouse 
    }

    // public void InstantiateBird(BirdSO birdName) {    
    //     //random instantiation
    //     //needed.?
    //      what about random instantiation of all birds at the start?
    // }

    public void InstantiateBird(BirdSO birdName, int x, int y) {    
        //instantiate 

    }

    public void RefreshBirds() {
        for (int i = 0; i < birds.Count; i++) {
            if (birds[i].found) InstantiateBird(birds[i], 0, 0);
        }
    }
}
