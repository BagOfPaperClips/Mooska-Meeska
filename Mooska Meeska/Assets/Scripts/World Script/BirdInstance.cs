using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using TMPro;

public class BirdInstance : MonoBehaviour
{
    public BirdSO data;
    float timer = 0;

    public GameObject defaultModel;
    public GameObject foundModel;
    
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI alertText;
    Coroutine timerCoroutine;

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
        if (hostile && TrackSun.instance != null && TrackSun.instance.hidden)
        {
            CancelDive();
            alertText.text = "SAFE";

        }

    }


    public void diveStart() 
    {
        if (state != BirdState.OnSpline) return; // 

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
        
        while (current > 0) {
        
            timerText.text = Mathf.CeilToInt(current).ToString();
            current -= Time.deltaTime;  
            yield return null;

        }
                alertText.text = "DEAD";
        timerCoroutine = null; // mark finished
        diveEnd();     
    }

    public void diveEnd()
    {
           if (state != BirdState.Diving) return;

    hostile = false;
    state = BirdState.OnSpline;

    alertText.text = "DEAD";
    timerText.text = "";
  }


    public void endTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    void CancelDive()
    {
        // endTimer(); // stop countdown early
        // diveEnd();  // cleanup + return

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
