using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class SimonSays : MonoBehaviour
{
    private int num;

    [SerializeField] GameObject button1;
    
    [SerializeField] GameObject button2;

    [SerializeField] GameObject button3;

    [SerializeField] GameObject button4;

    [SerializeField] TextMeshProUGUI text1;

    int total = 0;

    bool chosen = false;

    bool gameStart = true;

    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            gameStart = false;
            StartCoroutine(GameStateChange());
        }
    }

    IEnumerator GameStateChange()
    {

        startGame();

        yield return new WaitForSeconds(1f);
        
        allOn();
    }

    void startGame()
    {
        chosen = true;
        randomNumber();
        currentTime = 0;
        showButton();
    }
    
    void allOn()
    {
        button1.SetActive(true);
        button2.SetActive(true);
        button3.SetActive(true);
        button4.SetActive(true);
    }

    void showButton()
    {
        switch (num)
        {
            case 1:
                button1.SetActive(true);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(false);
                break;

            case 2:
                button1.SetActive(false);
                button2.SetActive(true);
                button3.SetActive(false);
                button4.SetActive(false);
                break;

            case 3:
                button1.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(true);
                button4.SetActive(false);
                break;

            case 4:
                button1.SetActive(false);
                button2.SetActive(false);
                button3.SetActive(false);
                button4.SetActive(true);
                break;
        }
    }

    void randomNumber()
    {
        num = Random.Range(4, 0);
        Debug.Log("RandomNumber: " + num);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (total <= 5)
        {
            if (collision.CompareTag("Button1"))
            {
                if (num == 1)
                {
                    button1.SetActive(false);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    button4.SetActive(false);

                    //text1.text = "I got one";
                    total += 1;
                }
                else
                {
                    //text1.text = "Oops, Wrong";
                }

                gameStart = true;

            }

            if (collision.CompareTag("Button2"))
            {
                if (num == 2)
                {
                    button1.SetActive(false);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    button4.SetActive(false);

                    //.text = "I got one";
                    total += 1;
                }
                else
                {
                    //text1.text = "Oops, Wrong";
                }
                gameStart = true;
            }

            if (collision.CompareTag("Button3"))
            {
                if (num == 3)
                {
                    button1.SetActive(false);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    button4.SetActive(false);

                    //text1.text = "I got one";
                    total += 1;
                }
                else
                {
                    //text1.text = "Oops, Wrong";
                }
                gameStart = true;
            }

            if (collision.CompareTag("Button4"))
            {
                if (num == 4)
                {
                    button1.SetActive(false);
                    button2.SetActive(false);
                    button3.SetActive(false);
                    button4.SetActive(false);

                    //text1.text = "I got one";
                    total += 1;
                }
                else
                {
                    //text1.text = "Oops, Wrong";
                }
                gameStart = true;
            }
        }
        else
        {
            StartCoroutine(Text());

        }
    }

    IEnumerator Text()
    {

        text1.text = "I win";

        yield return new WaitForSeconds(1f);

        text1.text = "";
    }
}
