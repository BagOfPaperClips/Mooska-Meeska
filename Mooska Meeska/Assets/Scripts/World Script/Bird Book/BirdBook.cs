using System.Collections.Generic;
using UnityEngine;

public class BirdBook : MonoBehaviour
{
    public static BirdBook instance;

    [Header("Book pages")]
    [SerializeField] private GameObject[] pages;

    private BirdPage[] BookPages;

    [Header("Birds")]
    [SerializeField] private BirdSO[] Birds;

    private int currentIndex = 0;

    private Dictionary<int, BirdSO> birdId;

    [Header("Bird Spawner")]
    private BirdSpawner birdSpawner;

    private void Awake()
    {
       
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

        if (!PauseManager.instance.isPaused)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            MoveRight();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            MoveLeft();
        }
    }

    private void MoveRight()
    {
        currentIndex++;

        if (currentIndex >= pages.Length)
        {
            currentIndex = 0;
        }

        ShowOnlyIndex(currentIndex);
    }

    private void MoveLeft()
    {
        currentIndex--;

        if (currentIndex < 0)
        {
            currentIndex = pages.Length - 1;
        }

        ShowOnlyIndex(currentIndex);
    }

    private void LockAllPages()
    {
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
        if (so == null)
        {
            
            return;
            
        }
        UnlockID(so.id);
    }

    public void UnlockID(int id)
    {
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
