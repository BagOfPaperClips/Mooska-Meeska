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
    [SerializeField] private Image birdImage;

    [Header("Locked")]
    [SerializeField] private Sprite LockedBirdImage;

    public bool IsUnlocked { get; private set; }
    
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

        if (birdImage != null)
        {
            birdImage.sprite = LockedBirdImage;
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

        if (birdImage != null)
        {
            birdImage.sprite = birdSO.birdImage;
        }
    }
}
