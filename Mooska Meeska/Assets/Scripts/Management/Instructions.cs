using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Instructions : MonoBehaviour
{

    string[] pageText = 
    {
        "", "Avoid the birds flying overhead! If they spot you, " + 
        "you won't have much time to find cover..", "Interact with " +
        "wanted posters (cubes atm) to learn more about the bird mafia",
        "Find keys to unlock spaces and save Meeska!"
    };
    public int pageindex = 0;
    public TextMeshProUGUI bodyText;
    public TextMeshProUGUI nextBtn;
    public GameObject instructionPanel;
        public GameObject journalText;

    [SerializeField] private int count = 0;



    // Start is called before the first frame update
    void Start() {
        journalText.SetActive(false);
                if (PauseManager.instance != null)
        {
            PauseManager.instance.SetPaused(true);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            nextPage();
        }

        if (Input.GetKeyUp(KeyCode.Escape) && count < 1)
        {
            count++;

            instructionPanel.SetActive(false);
            PauseManager.instance.SetPaused(false);
            journalText.SetActive(true);
        }

    }
    public void nextPage() {
        if (pageindex == pageText.Length - 1) {
            instructionPanel.SetActive(false);
            PauseManager.instance.SetPaused(false);
            journalText.SetActive(true);
        }
        else {
            pageindex++;
            showPage();
            if (pageindex == pageText.Length - 1) {
                // nextBtn.Witdh = 140;
                nextBtn.text = "Start Game";
            }
         }
    }

    public void showPage() {
        bodyText.text = pageText[pageindex];
    }
}
