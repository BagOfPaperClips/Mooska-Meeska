using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ComicViewer : MonoBehaviour
{
    public Image comicImage;
    public Sprite[] pages;
    private int index = 0;

    public void NextPage()
    {
        if (index < pages.Length - 1)
        {
            index++;
            comicImage.sprite = pages[index];
        }
        else
        {
            SceneManager.LoadScene("Game");
        }
    }
}