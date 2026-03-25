using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapChanger : MonoBehaviour
{
    [SerializeField] int changeTo;
    [SerializeField] MinimapManager manager;
    [SerializeField] RespawnManager respawnManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.ChangeDistrict(changeTo);
            respawnManager.ChangeDistrict(changeTo);
        }
    }
}
