using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class KeyCollection : MonoBehaviour
{
    [SerializeField] int num = 0;
    [SerializeField] TextMeshProUGUI text1;
    [SerializeField] TextMeshProUGUI text2;

    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;
    [SerializeField] GameObject door3;
    [SerializeField] GameObject cage;

    int section = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        text2.enabled= false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        text2.enabled = true;
        if (collision.CompareTag("puzzle2"))
        {
            num += 1;
            Debug.Log("Score: " + num);
            

            if (num <= 2)
            {
                StartCoroutine(addScore());
                 
                if(num == 2)
                {
                    //open door1
                    door1.SetActive(false);
                    section = 2;
                }
            }
            else if(num <= 5)
            {
                StartCoroutine(addScore());

                if (num == 5)
                {
                    //open door1
                    door2.SetActive(false);
                    section = 3;
                }
            }
            else if (num <= 9)
            {
                StartCoroutine(addScore());

                if (num == 9)
                {
                    //open door1
                    door3.SetActive(false);
                    section = 4;
                }
            }
            else if (num <= 14)
            {
                StartCoroutine(addScore());

                if (num == 14)
                {
                    //open CAGE
                    cage.SetActive(false);
                }
            }

        }
    }

    IEnumerator addScore()
    {
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

        text1.text = "I think a door opened";
        yield return new WaitForSeconds(1f);
        text1.text = "";
    }

    IEnumerator cageOpen()
    {

        text1.text = "I think the cage opened!";
        yield return new WaitForSeconds(1f);
        text1.text = "";
    }
}
