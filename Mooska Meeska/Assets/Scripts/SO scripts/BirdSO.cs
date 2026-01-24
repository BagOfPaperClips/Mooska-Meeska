using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/BirdSO")]
public class BirdSO : ScriptableObject
{

   [Header("Identification")]
   public int id;

   [Header("Bird Log")]
   public string birdName;
   public string birdDescription;
   public int birdSpeed;

   [Header ("Audio")]
   public AudioClip birdCall;
   public Sprite birdImage;

   [Header("Reference")]
   public GameObject birdModel;
   public bool Hostile;
   



}
