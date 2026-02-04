using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrackSun : MonoBehaviour
{
    public Transform sun;
    public Transform player;
    public LayerMask wall;
    public LayerMask bird;
    public bool hidden;
    public static TrackSun instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }
    // Start is called before the first frame update
    void Update()
    {
        // if(Physics.Linecast(sun.position, player.position, wall))
        // {
        //     //PLAYER IN SHADOW

        //     Debug.Log("IN SHADOW");
        //     hidden = true;

        // }
        hidden = Physics.Linecast(sun.position, player.position, wall);

    
        RaycastHit hit;
        if(Physics.Linecast(sun.position, player.position, out hit, bird) && !hidden)
        {

            Debug.Log("CAUGHT");
            //hostile == true;
            //find the bird that caught it, go to individual instance (does that work when its not an instance.? and make dive methoid{})
            BirdInstance bird = hit.collider.GetComponentInParent<BirdInstance>();
            Debug.Log("Who's that pokemon? ITS " + bird.data.birdName);

            // bird.diveStart();
                    SceneManager.LoadScene("Death");

        }

        //PLAYER IN SUN
    }


}
