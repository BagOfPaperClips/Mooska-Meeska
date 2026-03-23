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

    private Vector3 checkpoint1 = new Vector3(-430f, -1f, -55f);
    private Vector3 checkpoint2 = new Vector3(-512.8f, -1f, -149f);
    private Vector3 checkpoint3 = new Vector3(-390, -1f, -227.1f);

    
    

    // Start is called before the first frame update
    void Start()
    {
        startpos = player.transform.position;
        Debug.Log("player position is at " + startpos);
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        keyCollection.text2.text = "";
        mouseLook.UnlockCursor();
        movement.enabled = false;

        
        if (keyCollection.Odoor3.activeSelf)
        {
            startpos = checkpoint3;
        }
        else if (keyCollection.Odoor2.activeSelf)
        {
            startpos = checkpoint2;
        }
        else if (keyCollection.Odoor1.activeSelf)
        {
            startpos = checkpoint1;
        }
       

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

    
}
