using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour
{
    [Header("References")]
    public BirdSO birdSO;
    private Transform player;
    public GameObject alert;

    [Header("DEBUGGING")]
    public float Distance;

    [Header("Inventory")]
    public InventoryManager inventoryManager;
    public KeySO key;
    

    private void Awake()
    {
        var p = GameObject.FindWithTag("Player");

        if (p != null)
        {
            player = p.transform;
        }
    }

    // Update is called once per frame


    private bool canInteract;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
    {
        canInteract = true;
        alert.SetActive(true);
    }
    }


    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
    {
        canInteract = false;
        alert.SetActive(false);
    }
    }

    void Update()
{
    if (!canInteract) return;

    if (Input.GetKeyDown(KeyCode.E))
    {
        switch (gameObject.tag)
        {
            case "Poster":
                PageCollected();
                break;
            case "FakeChest":
                NoKey();
                break;
            case "TrueChest":
                HasKey();
                break;
        }
    }
}

    void PageCollected()
    {
        if (BirdBook.instance != null)
        {
             
            BirdBook.instance.UnlockBird(birdSO);
        }

        Destroy(gameObject);
    }


    void NoKey()
    {   
        
        Debug.Log("Dang, it's empty");
        Destroy(gameObject);
    }

    void HasKey()
    {

        Debug.Log("You found a key");
        inventoryManager.AddKey(key);
        Destroy(gameObject);
       

    }
}
