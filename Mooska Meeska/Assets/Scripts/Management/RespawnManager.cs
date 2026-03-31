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

    
    private Vector3 checkpoint1 = new Vector3(-1158.01f, 0.07f, -1649.6f);
    private Vector3 checkpoint2 = new Vector3(-1157.21f, 0.07f, -1710.38f);
    private Vector3 checkpoint3 = new Vector3(-1240.59f, 0.07f, -1809.12f);
    private Vector3 checkpoint4 = new Vector3(-1111.5f, 0.07f, -1884.1f);

    
    

    // Start is called before the first frame update
    void Start()
    {
        startpos = checkpoint1;
        Debug.Log("player position is at " + startpos);
        this.gameObject.SetActive(false);
    }

    void OnEnable()
    {
       
        mouseLook.UnlockCursor();
        player.gameObject.GetComponent<Movement>().enabled = false;
        player.gameObject.GetComponent<CharacterController>().enabled = false;

        
        
       

    }

    void OnDisable()
    {
        

        player.gameObject.GetComponent<Movement>().enabled = true;
        player.gameObject.GetComponent<CharacterController>().enabled = true;
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
