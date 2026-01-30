using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class BirdSpawner : MonoBehaviour
{

public List<BirdSO> birds;

   
    // Start is called before the first frame update
    void Start()
    {
        RefreshBirds();
    }

    // Update is called once per frame
    void Update()
    {
       //if bird catches mouse, hostile = true, timer starts, animation starts
       //if hidden = true, timer ends and hostile = false
       //else if (timer = 0) kill mouse 
    }

    public void InstantiateSpline(BirdSO bird) {
        Vector3 position = new Vector3(0, 0, 0);
        // Instantiate(bird.splinePrefab, position, Quaternion.identity);
        Instantiate(bird.birdPrefab, position, Quaternion.identity);

        SplineAnimate anim = bird.birdPrefab.GetComponent<SplineAnimate>();
        anim.StartOffset = 10;
    }

    public void RefreshBirds() {
        for (int i = 0; i < birds.Count; i++) {
            InstantiateSpline(birds[i]);
        }
    }
}
