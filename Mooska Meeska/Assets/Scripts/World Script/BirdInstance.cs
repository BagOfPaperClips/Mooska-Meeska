using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInstance : MonoBehaviour
{
    public BirdSO data;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void diveStart() {
        startTimer();
        //diving animation using a linecast
    }

    public void startTimer() {
        Debug.Log("Dive started, lasting " + data.diveTimer + " seconds");
        // float diveLen = data.diveTimer;
        // timer += Time.deltaTime;
        // //use a coroutine instead
        // //if mouse = hidden, hostile = false;
        // if (timer >= diveLen) {
        //     //kill
        // }
    }

    public void diveEnd() {
        
    }
}
