using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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


    // Start is called before the first frame update
    void Start() {
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

    }
    public void nextPage() {
        if (pageindex == pageText.Length - 1) {
            instructionPanel.SetActive(false);
            PauseManager.instance.SetPaused(false);

        }
        else {
            pageindex++;
            showPage();
            if (pageindex == pageText.Length - 1) {
                nextBtn.text = "Start Game";
            }
         }
    }

    public void showPage() {
        bodyText.text = pageText[pageindex];
    }
}
