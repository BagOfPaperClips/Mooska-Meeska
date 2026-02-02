using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class BirdInstance : MonoBehaviour
{
    public BirdSO data;
    float timer = 0;

    SplineAnimate splineAnim;
    SplineContainer spline;

    void Awake()
    {

        splineAnim = GetComponent<SplineAnimate>();
        spline = GetComponent<SplineContainer>();
        
    }

    enum BirdState
    {

    OnSpline,
    Diving,
    Returning

    }

BirdState state = BirdState.OnSpline;

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
