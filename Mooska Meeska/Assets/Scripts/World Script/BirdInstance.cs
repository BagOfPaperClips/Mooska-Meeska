using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using TMPro;

public class BirdInstance : MonoBehaviour
{
    public BirdSO data;
    private float timerSpeed = 1f;


    public GameObject defaultModel;
    public GameObject foundModel;
    
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI alertText;
    Coroutine timerCoroutine;

    // private float remainingTime;
    public bool hostile = false;
    BirdState state = BirdState.OnSpline;

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

    void Update() 
    {
        if (state == BirdState.Diving && TrackSun.instance != null && TrackSun.instance.hidden)
        {
            CancelDive();

        }

    }


    public void diveStart() 
    {
        if (state == BirdState.Diving) return; // 

            state = BirdState.Diving;
            hostile = true;

            alertText.text = "SPOTTED";

            if (timerCoroutine != null)
                StopCoroutine(timerCoroutine);

            timerCoroutine = StartCoroutine(startTimer(data.diveTimer));

        //diving animation, bird leaves spline
    }

    public IEnumerator startTimer(float timer) 
    {
        float current = timer;
        
        while (current > 1) {
        
            timerText.text = current.ToString("0");
            yield return new WaitForSeconds(timerSpeed);
            current -= timerSpeed;  


        }
        timerCoroutine = null; // mark finished
        diveEnd();
    }

    public void diveEnd()
    {
           if (state == BirdState.OnSpline) return;

    hostile = false;
    state = BirdState.OnSpline;

    alertText.text = "DEAD";
    timerText.text = "";
  }


    void CancelDive()
    {

        if (state != BirdState.Diving) return;

        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }

        hostile = false;
        state = BirdState.OnSpline;

        alertText.text = "SAFE";
        timerText.text = "";
    }

}
