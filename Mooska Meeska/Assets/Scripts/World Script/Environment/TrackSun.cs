using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSun : MonoBehaviour
{


    public Transform sun;          // I lasso the sun
    public Transform player;

    public LayerMask wall;
    public LayerMask bird;

    public bool hidden;

    public static TrackSun instance;

    private MouseLook mouseLook;
    private LayerMask detectionMask;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        mouseLook = FindFirstObjectByType<MouseLook>();
        detectionMask = wall | bird;
    }

    void Update()
    {
        Vector3 sunDirection = -sun.forward; 

        Debug.DrawRay(player.position, sunDirection * 100f, Color.yellow);

        RaycastHit hit;

        if (Physics.Raycast(player.position, sunDirection, out hit, 1000f, detectionMask))
        {
            

            if (((1 << hit.collider.gameObject.layer) & wall) != 0)
            {
                Debug.Log("Don't be suspicious");
                
                hidden = true;
                return;
            }

            else if (((1 << hit.collider.gameObject.layer) & bird) != 0)
            {
                hidden = false;

                Debug.Log("CAUGHT");

                BirdInstance birdInstance = hit.collider.GetComponentInParent<BirdInstance>();

                if (birdInstance != null)
                {
                    Debug.Log("Who's that pokemon? ITS " + birdInstance.data.birdName);
                }

                mouseLook.UnlockCursor();
                SceneManager.LoadScene("Death");
            }
        }
        else
        {
            // Nothing blocking sunlight
            hidden = false;
        }
    }



    // public Transform sun;
    // public Transform player;
    // public LayerMask wall;
    // public LayerMask bird;
    // public bool hidden;
    // public static TrackSun instance;
    // private MouseLook mouseLook;

    // void Awake()
    // {
    //     if (instance != null && instance != this)
    //     {
    //         Destroy(gameObject);
    //         return;
    //     }

    //     instance = this;

    //     mouseLook = FindFirstObjectByType<MouseLook>();
    // }
    // // Start is called before the first frame update
    // void Update()
    // {
    //     // if(Physics.Linecast(sun.position, player.position, wall))
    //     // {
    //     //     //PLAYER IN SHADOW

    //     //     Debug.Log("IN SHADOW");
    //     //     hidden = true;

    //     // }
        
    //     Vector3 sunDirection = -sun.forward;
        
    //     hidden = Physics.Linecast(sun.position, player.position, wall);

    
    //     RaycastHit hit;
    //     if(Physics.Linecast(sun.position, player.position, out hit, bird) && !hidden)
    //     {

    //         Debug.Log("CAUGHT");
    //         //hostile == true;
    //         //find the bird that caught it, go to individual instance (does that work when its not an instance.? and make dive methoid{})
    //         BirdInstance bird = hit.collider.GetComponentInParent<BirdInstance>();
    //         Debug.Log("Who's that pokemon? ITS " + bird.data.birdName);
    //         mouseLook.UnlockCursor();
    //         //bird.diveStart();
    //         SceneManager.LoadScene("Death");

    //     }

    //     //PLAYER IN SUN
    // }


}
