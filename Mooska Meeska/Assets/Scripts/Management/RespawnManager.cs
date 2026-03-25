using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RespawnManager : MonoBehaviour
{
    
    
    [SerializeField] Vector3 startpos;
    [SerializeField] GameObject player;
    [SerializeField] MouseLook mouseLook;

    [SerializeField] Movement movement;
    
    [SerializeField] SceneLoader sceneLoader;

    [SerializeField] KeyCollection keyCollection;

    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    
    private Vector3 checkpoint1 = new Vector3(-1158.01f, -1f, -1649.6f);
    private Vector3 checkpoint2 = new Vector3(-1157.21f, -1f, -1710.38f);
    private Vector3 checkpoint3 = new Vector3(-1240.59f, -1f, -1809.12f);
    private Vector3 checkpoint4 = new Vector3(-1111.5f, -1f, -1884.1f);

    
    

    // Start is called before the first frame update
    void Start()
    {
        startpos = player.transform.position;
        Debug.Log("player position is at " + startpos);
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        // keyCollection.text2.text = "";
        // keyCollection.text1.text = "";
        mouseLook.UnlockCursor();
        movement.enabled = false;

        
        // if (keyCollection.Odoor3.activeSelf)
        // {
        //     startpos = checkpoint3;
        // }
        // else if (keyCollection.Odoor2.activeSelf)
        // {
        //     startpos = checkpoint2;
        // }
        // else if (keyCollection.Odoor1.activeSelf)
        // {
        //     startpos = checkpoint1;
        // }
       

    }

    void OnDisable()
    {
        

        movement.enabled = true;
    }


    public void Respawn()
    {
        player.transform.position = startpos;

        mouseLook.LockCursor();
        
        this.gameObject.SetActive(false);
    }

    public void Quit()
    {
        SceneManager.LoadScene("Death");

        
    }


    public void ChangeDistrict(int changeTo)
    {
        if(changeTo == 0)
        {
            startpos = checkpoint1;
        }
        else if(changeTo == 1)
        {
            startpos = checkpoint2;
            Debug.Log("blep");
        }
        else if(changeTo == 2)
        {
            startpos = checkpoint3;
        }
        else if(changeTo == 3)
        {
            startpos = checkpoint4;
        }
    }


}
