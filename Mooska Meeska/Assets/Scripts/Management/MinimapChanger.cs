using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapChanger : MonoBehaviour
{
    [SerializeField] int changeTo;
    [SerializeField] MinimapManager manager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.ChangeDistrict(changeTo);
        }
    }
}
