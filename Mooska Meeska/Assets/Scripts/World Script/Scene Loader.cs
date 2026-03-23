using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SceneLoader : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Image LoadingBarFill;
    [SerializeField] private Image LoadingMouse;

    [Header("Fill")]
    //[SerializeField] private float MaxfillSpeed = 2.5f;
    //[SerializeField] private float MinfillSpeed = 5.5f;
    [Range(0.1f, 1.0f)] [SerializeField] private float fillSpeed = 0.4f;
    [SerializeField] private float maxRange = 30.0f;
    [SerializeField] private float minRange = -27.0f;

    [Header("UI Warmup")]
    [SerializeField] private bool preWarm = true;
    [SerializeField] private float birdBookShowTime = 1.0f;
    [SerializeField] private float pauseMenuShowTime = 0.5f;

    [Header("Debug")]
    [SerializeField] private float BarFill;

    private BirdBookManager birdBookManager;
    private PauseManager pauseManager;

    private RectTransform mouseRect;
    private float mouseY;

    public bool IsLoading { get; private set; }
    private bool finishing;

    private Coroutine fillCoroutine;
    private Coroutine warmCoroutine;

    private void Awake()
    {

        //if (MinfillSpeed > MaxfillSpeed)
        //{
        //    float temp = MinfillSpeed;
        //    MinfillSpeed = MaxfillSpeed;
        //    MaxfillSpeed = temp;
        //}

        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive(true);
        }

        if (LoadingBarFill != null)
        {
            LoadingBarFill.fillAmount = 0f;
        }

        if (LoadingMouse != null)
        {
            mouseRect = LoadingMouse.rectTransform;
            mouseY = mouseRect.anchoredPosition.y;
        }
        BarFill = LoadingBarFill.fillAmount;

        BeginLoading();
        birdBookManager = FindFirstObjectByType<BirdBookManager>();
        pauseManager = FindFirstObjectByType<PauseManager>();
    }

    public void BeginLoading()
    {
        IsLoading = true;
        //fillSpeed = Random.Range(MinfillSpeed, MaxfillSpeed);

        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive(true);
        }

        if (LoadingBarFill != null)
        {
            LoadingBarFill.fillAmount = 0f;
        }

        finishing = false;

        if (fillCoroutine != null)
        {
            StopCoroutine(fillCoroutine);
        }

        fillCoroutine = StartCoroutine(FillRoutine());

        if (preWarm)
        {
            if (warmCoroutine != null)
            {
                StopCoroutine(warmCoroutine);
            }
            warmCoroutine = StartCoroutine(preWarmRoutine());
        }
    }

    public void FinishLoading()
    {
        finishing = true;
    }

    private void Update()
    {
        
        if (LoadingBarFill != null || mouseRect != null)
        {
            float x = Mathf.Lerp(minRange, maxRange, LoadingBarFill.fillAmount);
            mouseRect.anchoredPosition = new Vector2(x, mouseY);
        }
    }

    private IEnumerator FillRoutine()
    {
        if (LoadingBarFill == null)
        {
            yield break;
        }

        while (true)
        {
            float dt = Time.unscaledDeltaTime;

            float target = 0.9f;


            if (finishing)
            {
                target = 1.0f;
            }

            if (LoadingBarFill.fillAmount < target)
            {
                LoadingBarFill.fillAmount += fillSpeed * dt;
            }

            if (finishing && LoadingBarFill.fillAmount >= 1.0f)
            {
                LoadingBarFill.fillAmount = 1.0f;

                if (LoadingScreen != null)
                {
                    LoadingScreen.SetActive(false);
                }

                IsLoading = false;
                yield break;
            }

            yield return null;
        }
    }

    private IEnumerator preWarmRoutine()
    {
        yield return null;

        if (birdBookManager != null)
        {
            birdBookManager.ForceShow(true);
            Debug.Log("Bird Book Waiting");
            yield return new WaitForSecondsRealtime(birdBookShowTime);
            Debug.Log("Bird Book Done Waiting");
            birdBookManager.ForceShow(false);
        }

        yield return null;

        if (pauseManager != null)
        {
            pauseManager.ForcePauseShow(true);
            Debug.Log("Pause Waiting");
            yield return new WaitForSecondsRealtime(pauseMenuShowTime);
            Debug.Log("Pause Done Waiting");
            pauseManager.ForcePauseShow(false);
        }

        FinishLoading();
    }

}
