using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class TrackSun : MonoBehaviour
{
    public Transform sun;
    public Transform player;
    public LayerMask wall;
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
        
        else {
            hidden = false;
        }

        //PLAYER IN SUN
    }
}
