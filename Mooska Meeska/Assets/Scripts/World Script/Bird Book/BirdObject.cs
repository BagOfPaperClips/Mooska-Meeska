using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdObject : MonoBehaviour
{

    [Header("Scriptable Object")]
    public BirdSO birdSO;

    [Header("Models")]
    [SerializeField] private GameObject defaultModels;
    [SerializeField] private GameObject foundModels;

    private void Awake()
    {
        if (defaultModels == null)
        {
            Transform t = transform.Find("DefaultModel");

            if (t != null)
            {
                defaultModels = t.gameObject;
            }
        }

        if (foundModels == null)
        {
            Transform t = transform.Find("FoundModel");

            if (t != null)
            {
                foundModels = t.gameObject;
            }
        }
        updateModel();
    }

    private void Update()
    {
        updateModel();
    }

    public void updateModel()
    {
        bool found = false;

        if (birdSO != null)
        {
            found = birdSO.found;
        }

        if (defaultModels != null)
        {
            defaultModels.SetActive(!found);
        }

        if (foundModels != null)
        {
            foundModels.SetActive(found);
        }
    }
}



