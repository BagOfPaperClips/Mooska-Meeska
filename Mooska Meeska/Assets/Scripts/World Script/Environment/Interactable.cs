using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    [Header("References")]
    public BirdSO birdSO;
    private Transform player;

    [Header("DEBUGGING")]
    public float Distance;
    private void Awake()
    {
        var p = GameObject.FindWithTag("Player");

        if (p != null)
        {
            player = p.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, player.position);

        if (Distance <= 3.0f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {

                switch (gameObject.tag)
                {
                    case "Poster":
                    PageCollected();
                    break;
                    case "FakeChest":
                    NoKey();
                    break;
                    case "TrueChest":
                    HasKey();
                    break;

                }
                
                
                
            }
        }
    }

    void PageCollected()
    {
        if (BirdBook.instance != null)
        {
             
            BirdBook.instance.UnlockBird(birdSO);
        }

        Destroy(gameObject);
    }


    void NoKey()
    {   
        
        Debug.Log("Dang, it's empty");
        Destroy(gameObject);
    }

    void HasKey()
    {

        Debug.Log("You found a key");
        Destroy(gameObject);
    }
}
