using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    [SerializeField] Light l;
    [SerializeField] Material floor;
    // Start is called before the first frame update
    void Start()
    {
        floor.color = new Color(0.4392157f, 1f, 0.4f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        //text2.enabled = true;
        if (collision.CompareTag("ColourChange1"))
        {
            //l.color = new Color(255,163,0);
            floor.color= new Color(0.4392157f, 1f, 0.4f, 0);
        }
        if (collision.CompareTag("ColourChange2"))
        {
            Debug.Log("AREA2");
            //l.color = new Color(60, 60, 96);
            floor.color = new Color(0.60f, 0.5706564f, 0.8566037f, 0);
        }
        if (collision.CompareTag("ColourChange3"))
        {
            //l.color = new Color(26, 26, 26);
            floor.color = new Color(0.7660377f, 0.6866364f, 0.5766963f, 0);
        }
        if (collision.CompareTag("ColourChange4"))
        {
            //l.color = new Color(173, 193, 138);
            floor.color = new Color(0.4257591f, 0, 0.4207546f ,0);
        }
    }
}
