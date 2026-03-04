using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BirdPage : MonoBehaviour
{
    [Header("ID")]
    public int ID;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Stats;
    [SerializeField] private Image birdImage;

    private BirdBook birdBook;

    public bool IsUnlocked { get; private set; }

    private void Awake()
    {
        if (birdBook == null)
        {
            birdBook = FindFirstObjectByType<BirdBook>();
        }
    }

    public void setLocked(BirdSO so)
    {
        IsUnlocked = false;

        if (Name != null)
        {
            Name.text = so.LockedBirdName;
        }

        if (Description != null)
        {
            Description.text = so.LockedBirdDescription;
        }

        if (Stats != null)
        {
            Stats.text = so.LockedBirdStats;
        }

        if (birdImage != null)
        {
            
            birdImage.sprite = birdBook.defaultImage;
        }
    }

    public void BirdSet(BirdSO birdSO)
    {
        if (birdSO == null)
        {
            return;
        }


        IsUnlocked = true;

        if (Name != null)
        {
            Name.text = birdSO.birdName;
        }

        if (Description != null)
        {
            Description.text = birdSO.birdDescription;
        }

        if (Stats != null)
        {
            Stats.text = birdSO.birdStats;
        }

        if (birdImage != null)
        {
            birdImage.sprite = birdSO.birdImage;
        }

        if (birdImage == null)
        {
            birdImage.sprite = null;
        }
    }
}
