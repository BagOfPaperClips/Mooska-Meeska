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
    [Header ("UI")]
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Image LoadingBarFill;

    [Header("Fill")]
    [SerializeField] private float MaxfillSpeed = 2.5f;
    [SerializeField] private float MinfillSpeed = 5.5f;
    private float fillSpeed;


    private bool finishing;

    private void Awake()
    {


        if (MinfillSpeed > MaxfillSpeed)
        {
            float temp = MinfillSpeed;
            MinfillSpeed = MaxfillSpeed;
            MaxfillSpeed = temp;
        }

        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive (true);
        }

        if (LoadingBarFill != null)
        {
            LoadingBarFill.fillAmount = 0f;
        }

        BeginLoading();
    }

    public void BeginLoading()
    {
        fillSpeed = Random.Range(MinfillSpeed, MaxfillSpeed);
        finishing = false;

        if (LoadingScreen != null)
        {
            LoadingScreen.SetActive(true);
        }

        if (LoadingBarFill != null)
        {
            LoadingBarFill.fillAmount = 0f;
        }

        StopAllCoroutines();
        StartCoroutine(FillRoutine());
    }

    public void FinishLoading()
    {
        finishing = true;
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

                yield break;
            }

            yield return null;
        }
    }
}
