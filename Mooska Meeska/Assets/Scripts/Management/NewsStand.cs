using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewsStand : MonoBehaviour
{
    [Header("References")]
    public BirdSO birdSO;


    [Header("Display")]
    public TextMeshProUGUI text;
   
    public Material Onmat;
    public Material OffMat;
    public Renderer rendy;
    private bool alreadyCollected;


    

    
    
    
    void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player")) return;
        if (alreadyCollected) return;

        PageCollected();

        GetComponent<Collider>().enabled = false;
    }

    void PageCollected()
    {
        if (BirdBook.instance != null)
            BirdBook.instance.UnlockBird(birdSO);
        
        text.text = "You have collected a page\nfor the Bird Book";
        

        alreadyCollected = true;

        text.gameObject.SetActive(true);
        StartCoroutine(TurnOffNews());
    }

    IEnumerator TurnOffNews()
    {
        
        
        yield return new WaitForSeconds(3);

        text.gameObject.SetActive(false);
        rendy.gameObject.SetActive(false);
    }
}
