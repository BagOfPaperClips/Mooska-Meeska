using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class KeyCollection : MonoBehaviour
{
    [SerializeField] int num = 0;
    [SerializeField] TextMeshProUGUI text1;

    [SerializeField] GameObject door1;
    [SerializeField] GameObject door2;
    [SerializeField] GameObject door3;
    [SerializeField] GameObject cage;

    int section = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
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
            else if(num <= 6)
            {
                StartCoroutine(addScore());

                if (num == 6)
                {
                    //open door1
                    door2.SetActive(false);
                    section = 3;
                }
            }
            else if (num <= 12)
            {
                StartCoroutine(addScore());

                if (num == 12)
                {
                    //open door1
                    door3.SetActive(false);
                    section = 4;
                }
            }
            else if (num <= 20)
            {
                StartCoroutine(addScore());

                if (num == 20)
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
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if(num == 2)
                {
                    StartCoroutine(doorOpen());
                }
                break;
            case 2:
                text1.text = (num-2) + "/4";
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if (num == 6)
                {
                    StartCoroutine(doorOpen());
                }
                break;
            case 3:
                text1.text = (num-6) + "/6";
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if (num == 12)
                {
                    StartCoroutine(doorOpen());
                }
                break;
            case 4:
                text1.text = (num-12) + "/8";
                yield return new WaitForSeconds(1f);
                text1.text = "";
                if (num == 20)
                {
                    StartCoroutine(doorOpen());
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
}
