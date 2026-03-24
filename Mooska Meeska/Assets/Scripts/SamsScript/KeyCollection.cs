using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;
public class KeyCollection : MonoBehaviour
{
    [SerializeField] int num = 0;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

    public GameObject door1;
    public GameObject Odoor1;

    public GameObject door2;
    public GameObject Odoor2;

    public GameObject door3;
    public GameObject Odoor3;

    public GameObject cage;
    public GameObject Ocage;

    public GameObject doorDialog1;
    public GameObject doorDialog2;
    public GameObject doorDialog3;
    public GameObject doorDialog4;

    int section = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        text2.text = "";
        //text2.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        //text2.enabled = true;
        if (collision.CompareTag("puzzle2"))
        {
            num += 1;
            Debug.Log("Score: " + num);
            

            if (num <= 2)
            {
                StartCoroutine(addScore());
                 
                if(num == 2)
                {
                    doorDialog1.SetActive(false);
                    //open door1
                    door1.SetActive(false);
                    Odoor1.SetActive(true);
                    section = 2;
                    Debug.Log("Assertation");
                }
            }
            else if(num <= 5)
            {
                StartCoroutine(addScore());

                if (num == 5)
                {
                    doorDialog2.SetActive(false);
                    //open door1
                    door2.SetActive(false);
                    Odoor2.SetActive(true);
                    section = 3;
                    Debug.Log("Dissertation");
                }
            }
            else if (num <= 9)
            {
                StartCoroutine(addScore());

                if (num == 9)
                {
                    doorDialog3.SetActive(false);
                    //open door1
                    door3.SetActive(false);
                    Odoor3.SetActive(true);
                    section = 4;
                }
            }
            else if (num <= 14)
            {
                StartCoroutine(addScore());

                if (num == 14)
                {
                    doorDialog4.SetActive(false);
                    //open CAGE
                    cage.SetActive(false);
                    Ocage.SetActive(true);
                }
            }
            if (collision.CompareTag("ThroughDoor"))
            {
                text2.text = "";
                text1.text = "";
            }

        }
    }

    IEnumerator addScore()
    {
        text2.fontSize = 150;
        text1.fontSize = 120;
        switch (section)
        {
            case 1:
                text1.text = num + "/2";
                text2.text = num + "/2";
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if(num == 2)
                {
                    StartCoroutine(doorOpen());
                }
                break;
            case 2:
                text1.text = (num- 2) + "/3";
                text2.text = (num - 2) + "/3";
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if (num == 5)
                {
                    StartCoroutine(doorOpen());
                }
                break;
            case 3:
                text1.text = (num- 5) + "/4";
                text2.text = (num - 5) + "/4";
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if (num == 9)
                {
                    StartCoroutine(doorOpen());
                }
                break;
            case 4:
                text1.text = (num-9) + "/5";
                text2.text = (num - 9) + "/5";
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if (num == 14)
                {
                    StartCoroutine(cageOpen());
                }
                break;
        }
    }

    IEnumerator doorOpen()
    {
        text2.fontSize = 100;
        text1.fontSize = 85;
        text1.text = "I think a door opened";
        text2.text = "Find the Door";
        yield return new WaitForSeconds(2.5f);
        text1.text = "";
    }

    IEnumerator cageOpen()
    {
        text2.fontSize = 100;
        text1.fontSize = 85;
        text1.text = "I think the cage opened!";
        text2.text = "Find the Cage";
        yield return new WaitForSeconds(2.5f);
        text1.text = "";
    }


    public bool getOdoor1()
    {
        return Odoor1.activeSelf;
    }

    public bool getOdoor2()
    {
        return Odoor2.activeSelf;
    }

    public bool getOdoor3()
    {
        return Odoor3.activeSelf;
    }

    public bool getOcage()
    {
        return Ocage.activeSelf;
    }

}
