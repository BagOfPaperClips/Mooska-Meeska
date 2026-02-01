using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrackSun : MonoBehaviour
{
    public Transform sun;
    public Transform player;
    public LayerMask wall;
    public LayerMask bird;
    public bool hidden;

    // Start is called before the first frame update
    void Update()
    {
        if(Physics.Linecast(sun.position, player.position, wall))
        {
            //PLAYER IN SHADOW

            Debug.Log("IN SHADOW");
            hidden = true;

        }

        RaycastHit hit;
        if(Physics.Linecast(sun.position, player.position, out hit, bird))
        {

            Debug.Log("CAUGHT");
            //hostile == true;
            //find the bird that caught it, go to individual instance (does that work when its not an instance.? and make dive methoid{})
            BirdInstance bird = hit.collider.GetComponentInParent<BirdInstance>();
            Debug.Log("Who's that pokemon? ITS " + bird.data.birdName);
            bird.diveStart();
        }
        
        else {
            hidden = false;
        }

        //PLAYER IN SUN
    }
}
