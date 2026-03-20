using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnManager : MonoBehaviour
{
    
    
    [SerializeField] Vector3 startpos;
    [SerializeField] GameObject player;
    [SerializeField] MouseLook mouseLook;
    
    [SerializeField] SceneLoader sceneLoader;

    public static RespawnManager instance {get; private set;}
    public bool isCaught { get; private set; }
    
    

    // Start is called before the first frame update
    void Start()
    {
        startpos = player.transform.position;
        Debug.Log("player position is at " + startpos);
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
        mouseLook.UnlockCursor();
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
