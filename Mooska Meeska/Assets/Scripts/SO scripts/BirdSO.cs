using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/BirdSO")]
public class BirdSO : ScriptableObject
{

   [Header("Identification")]
   public int id;

   [Header("Model Prefab")]
   public GameObject birdPrefab;
   public GameObject splinePrefab;

   [Header("Bird Log")]
   public string birdName;
   [TextArea]public string birdDescription;


   [Header ("Audio")]
   public AudioClip birdCall;

   [Header("Image")]
   public Sprite birdImage;

    [Header("Locked")]
    public string LockedBirdName;
    [TextArea] public string LockedBirdDescription;

   [Header("Reference")]
   public GameObject birdModel;
   public bool hostile;

   [Header("Data")]
   public bool found;
   public int birdSpeed;
   public int diveTimer;


 

}
