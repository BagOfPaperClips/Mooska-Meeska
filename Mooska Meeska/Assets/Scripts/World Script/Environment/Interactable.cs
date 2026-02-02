using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [Header("Display")]
    public TextMeshProUGUI text;
    public bool hold = false;
    

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
            case "Cage":
                OpenCage();
            break;
            case "Meeska":
                FreeMeeska();
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

        text.text = "You have collected a page\nfor the Bird Book";
        text.gameObject.SetActive(true);
        StartCoroutine(WaitForSeconds());

    }


    void NoKey()
    {   
        
        Debug.Log("Dang, it's empty");
        text.text = "Dang, it's empty";
        text.gameObject.SetActive(true);
        StartCoroutine(WaitForSeconds());

        
    }

    void HasKey()
    {

        Debug.Log("You found a key");
        text.text = "You Found a Key";
        text.gameObject.SetActive(true);
        StartCoroutine(WaitForSeconds());
        inventoryManager.AddKey(key);
    }

    void OpenCage()
    {
        if(inventoryManager.redKey != 0)
        {
            text.text = "You Open the Cage";
            text.gameObject.SetActive(true);
            StartCoroutine(WaitForSeconds());
        }
        else
        {
            text.text = "The Cage is Locked";
            text.gameObject.SetActive(true);
            hold = true;
            StartCoroutine(WaitForSeconds());
        }
    }

    void FreeMeeska()
    {
        SceneManager.LoadScene("Win");
    }


    IEnumerator WaitForSeconds()
    {
        yield return new WaitForSeconds(3);
        text.gameObject.SetActive(false);
        
        if(hold == false)
        {
            Destroy(gameObject);
            
        }

        hold = false;
        
        
    }
}
