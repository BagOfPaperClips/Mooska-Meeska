using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/BirdSO")]
public class BirdSO : ScriptableObject
{
   
   public string birdName;
   public string birdDescription;
   public int birdSpeed;
   public AudioClip birdCall;
   public Sprite birdImage;
   public GameObject birdModel;
   public bool Hostile;
   public int ID;



}
