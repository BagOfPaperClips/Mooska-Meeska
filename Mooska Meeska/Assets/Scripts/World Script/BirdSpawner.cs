using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{

public BirdSO firstBird; 
public Transform bird;
public TrackSun mouse;
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

    public void InstantiateBird(BirdSO birdName) {
//ONCE FOUND refresh all models
    }
}
