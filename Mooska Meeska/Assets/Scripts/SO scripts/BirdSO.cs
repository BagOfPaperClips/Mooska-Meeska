using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/BirdSO")]
public class BirdSO : ScriptableObject
{

   [Header("Identification")]
   public int id;

   // [Header("Model Prefab")]
   // public GameObject birdPrefab;

   [Header("Bird Log")]
   public string birdName;
   [TextArea]public string birdDescription;
   [TextArea] public string birdStats;


    [Header ("Audio")]
   public AudioClip birdCall;

   [Header("Image")]
   public Sprite birdImage;

    [Header("Locked")]
    public string LockedBirdName;
    [TextArea] public string LockedBirdDescription;
    [TextArea] public string LockedBirdStats;

    [Header("Reference")]
   public GameObject birdModel;
   public bool Hostile;

   [Header("Data")]
   public bool found;
   public string birdSpeed;
   public int diveTimer;
 

}
