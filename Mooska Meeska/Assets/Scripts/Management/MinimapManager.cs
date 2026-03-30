using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MinimapManager : MonoBehaviour
{
    [SerializeField] RawImage minimapImage;
    [SerializeField] List<Minimap> miniCams;

    public void ChangeDistrict(int i)
    {
        foreach (var r in miniCams)
        {
            r.minimapCamera.gameObject.SetActive(false);
        }

        miniCams[i].gameObject.SetActive(true);

        minimapImage.texture = miniCams[i].RenTex;
    }
}
