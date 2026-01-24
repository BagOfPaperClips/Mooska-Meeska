using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/BirdSO")]
public class BirdScriptableObject : ScriptableObject
{
   
   public string birdName;
   public string birdDescription;
   public int birdSpeed;
   public AudioClip birdCall;
   public Sprite birdImage;
   public GameObject birdModel;



}
