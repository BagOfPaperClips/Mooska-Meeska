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
        "you will die!", "Interact with the " +
        "News Stands to learn more about the bird mafia and keep track of them in your bird book!",
        "Collect the golden feathers to unlock doors in the area you're trapped in."+ 
        " These feathers are the keys to saving Meeska from her cage!"   

        // WHY WONT IT CHANGEEEEEEEEEEEEEEEEEEEEE 
        // pls WORK
        // it didnt change WHY ARE YOU SO DIFFICULT
        // omg spelling error
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
