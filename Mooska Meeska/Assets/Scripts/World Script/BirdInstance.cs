using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class BirdInstance : MonoBehaviour
{
    public BirdSO data;
    float timer = 0;

    public GameObject defaultModel;
    public GameObject foundModel;
    
    void Start()
    {
        updateModel();
    }

        public void updateModel()
    {
        defaultModel.SetActive(!data.found);
        foundModel.SetActive(data.found);
    }

    //for dive animation, to be implemented (backburner)
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
        //diving animation, bird leaves spline
    }

    public void startTimer() {
        Debug.Log("Dive started, lasting " + data.diveTimer + " seconds");
        // float diveLen = data.diveTimer; COROUTINE INSTEAD
        // timer += Time.deltaTime;
        // //use a coroutine instead
        // //if mouse = hidden, hostile = false;
        // if (timer >= diveLen) {
        //     //kill
        // }
    }

    public void diveEnd() {
        //bird returns to spline
    }
}
