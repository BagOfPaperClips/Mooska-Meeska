using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Puzzle2 : MonoBehaviour
{
    private int score = 0;

    [SerializeField] GameObject mouse; 
    [SerializeField] GameObject door;

    [SerializeField] TextMeshProUGUI rewardText;
    private float currentTime = 0;
    private int seconds;

    // Update is called once per frame
    void Update()
    {
        if(score == 4)
        {
            // OPEN GATE
            door.SetActive(false);

            // RUMBLE NOISE
            currentTime += Time.deltaTime;
            rewardText.text = "I think a door opened!";
            seconds = Mathf.FloorToInt(currentTime % 60);

            if (seconds >=3)
            {
                rewardText.text = "";
                currentTime = 0;
                score += 1;
            }
            // ADD ARROWS


            Debug.Log("Got them all");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("puzzle2"))
        {
            score += 1;
            Debug.Log("Score: "+ score);

        }
    }
}
