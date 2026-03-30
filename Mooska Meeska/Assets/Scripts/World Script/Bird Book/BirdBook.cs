using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BirdBook : MonoBehaviour
{
    public static BirdBook instance;

    [Header("Book pages")]
    [SerializeField] private GameObject[] pages;

    private BirdPage[] BookPages;
    private bool unlocked = false;

    [Header("Birds")]
    [SerializeField] private BirdSO[] Birds;

    private int currentIndex = 0;

    private Dictionary<int, BirdSO> birdId;

    [Header("Bird Spawner")]
    private BirdSpawner birdSpawner;

    [Header("Locked Book")]
    [SerializeField] private TextMeshProUGUI lockedBookText;
    [SerializeField] private float changeRatePerSecond = 5f;
    private Color initialColor;
    private bool revert = false;

    [Header("Reference")]
    public GameObject unlockedBook;
    public GameObject lockedBook;

    public Sprite defaultImage;

    private KeyCode PageRightKey;
    private KeyCode PageLeftKey;


    private void Awake()
    {
       unlocked = false;

        if (unlockedBook != null)
        {
            unlockedBook.SetActive(unlocked);
        }

        if (lockedBook != null)
        {
            lockedBook.SetActive(!unlocked);
        }

       for(int i = 0; i< Birds.Length; i++)
        {
            Birds[i].found = false;
        }
       
       
       
       if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        birdId = new Dictionary<int, BirdSO>();

        if (pages == null)
        {
            pages = new GameObject[0];
        }

        BookPages = new BirdPage[pages.Length];

        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] != null)
            {
                BookPages[i] = pages[i].GetComponent<BirdPage>();
            }
        }

        if (lockedBookText != null)
        {
            initialColor = lockedBookText.color;
        }
    }

    private void Start()
    {
        LockAllPages();
        ShowOnlyIndex(currentIndex);
    }

    private void Update()
    {
        if (pages == null || pages.Length == 0)
        {
            return;
        }

        if (PauseManager.instance == null)
        {
            return;
        }

        if (unlockedBook != null)
        {
            unlockedBook.SetActive(unlocked);
        }

        if (lockedBook != null)
        {
            lockedBook.SetActive(!unlocked);
        }

        PageRightKey = KeyBinding.GetKey(GameKeys.PageRight, KeyCode.L);
        PageLeftKey = KeyBinding.GetKey(GameKeys.PageLeft, KeyCode.K);



        if (Input.GetKeyDown(PageRightKey))
        {
            if (unlocked)
            {
                MoveRight();
            }

            else
            {
                TriggerLockedFlash();
            }
        }

        if (Input.GetKeyDown(PageLeftKey))
        {
            if (unlocked)
            {
                MoveLeft();
            }

            else
            {
                TriggerLockedFlash();
            }
        }

        if (revert && lockedBookText != null)
        {
            float t = changeRatePerSecond * Time.unscaledDeltaTime;
            lockedBookText.color = Color.Lerp(lockedBookText.color, initialColor, t);

            if (Vector4.Distance(lockedBookText.color, initialColor) < 0.01f)
            {
                lockedBookText.color = initialColor;
                revert = false;
            }
        }
    }

    private void TriggerLockedFlash()
    {
        if (lockedBookText == null)
        {
            return;
        }

        lockedBookText.color = Color.red;
        revert = true;
    }

    public void MoveRight()
    {
        TriggerLockedFlash();

        if (revert && lockedBookText != null)
        {
            float t = changeRatePerSecond * Time.unscaledDeltaTime;
            lockedBookText.color = Color.Lerp(lockedBookText.color, initialColor, t);

            if (Vector4.Distance(lockedBookText.color, initialColor) < 0.01f)
            {
                lockedBookText.color = initialColor;
                revert = false;
            }
        }

        currentIndex++;

        if (currentIndex >= pages.Length)
        {
            currentIndex = 0;
        }

        ShowOnlyIndex(currentIndex);
    }

    public void MoveLeft()
    {
        TriggerLockedFlash();

        if (revert && lockedBookText != null)
        {
            float t = changeRatePerSecond * Time.unscaledDeltaTime;
            lockedBookText.color = Color.Lerp(lockedBookText.color, initialColor, t);

            if (Vector4.Distance(lockedBookText.color, initialColor) < 0.01f)
            {
                lockedBookText.color = initialColor;
                revert = false;
            }
        }

        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = pages.Length - 1;
        }

        ShowOnlyIndex(currentIndex);
    }

    private void LockAllPages()
    {
        unlocked = false;
        if (BookPages == null)
        {
            return;
        }

        for (int i = 0; i < BookPages.Length; i++)
        {
            if (BookPages[i] != null)
            {
                BirdSO so = FindBirdbyID(BookPages[i].ID);
                BookPages[i].setLocked(so);
            }
        }
    }

    private BirdSO FindBirdbyID(int id)
    {
        if (Birds == null)
        {
            return null;
        }

        for (int i = 0; i < Birds.Length; i++)
        {
            if (Birds[i] != null && Birds[i].id == id)
            {
                return Birds[i];
            }
        }
        return null;
    }

    public void ShowOnlyIndex(int index)
    {
        if (pages == null || pages.Length == 0)
        {
            return;
        }

        if (index < 0)
        {
            index = pages.Length - 1;
        }
        else if (index >= pages.Length)
        {
            index = 0;
        }

        currentIndex = index;

        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] == null)
            {
                continue;
            }

            if (i == currentIndex)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(false);
            }
        }
    }

    public void UnlockBird(BirdSO so)
    {
        unlocked = true;
        if (so == null)
        {
            
            return;
            
        }
        UnlockID(so.id);
    }

    public void UnlockID(int id)
    {
        unlocked = true;
        if (BookPages == null)
        {
            return;
        }

        BirdSO so = FindBirdbyID(id);

        if (so == null)
        {
            return;
        }

        if (!so.found)
        {
            so.found = true;
            refreshBirdInstances(so);
        }
        for (int i = 0; i < BookPages.Length; i++)
        {
            BirdPage page = BookPages[i];
            if (page == null)
            {
                continue;
            }

            if (page.ID == id)
            {
                page.BirdSet(so);
            }
        }
    }

        void refreshBirdInstances(BirdSO so)
    {
        BirdInstance[] birds = FindObjectsOfType<BirdInstance>();

        foreach (BirdInstance bird in birds)
        {
            if (bird.data == so)
            {
                bird.updateModel();
            }
        }
    }

}
