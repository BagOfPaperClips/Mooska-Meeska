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

    [Header("Restored/Torn")]
    [SerializeField] private GameObject Restored;
    [SerializeField] private GameObject Torn;

    [Header("References")]
    [SerializeField] private TextMeshProUGUI Name;
    [SerializeField] private TextMeshProUGUI Description;
    [SerializeField] private TextMeshProUGUI Stats;
    [SerializeField] private Image birdSilhouette;
    [SerializeField] private Image birdImage;
    [SerializeField] private TextMeshProUGUI PageNumber;

    private BirdBook birdBook;

    public bool IsUnlocked { get; private set; }

    private void Awake()
    {
        if (birdBook == null)
        {
            birdBook = FindFirstObjectByType<BirdBook>();
        }

        if (Torn != null)
        {
            Torn.SetActive(!IsUnlocked);
        }

        if (Restored != null)
        {
            Restored.SetActive(IsUnlocked);
        }

        if (PageNumber != null)
        {
            PageNumber.text = ID.ToString();
        }
    }

    public void setLocked(BirdSO so)
    {
        IsUnlocked = false;

        Torn.SetActive(!IsUnlocked);
        Restored.SetActive(IsUnlocked);
    }

    public void BirdSet(BirdSO birdSO)
    {
        if (birdSO == null)
        {
            return;
        }


        IsUnlocked = true;

        Torn.SetActive(!IsUnlocked);
        Restored.SetActive(IsUnlocked);

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

        if (birdSilhouette != null)
        {
            birdSilhouette.sprite = birdSO.birdSilhouette;
        }

        if (birdImage != null)
        {
            birdImage.sprite = birdSO.birdImage;
        }

    }
}
