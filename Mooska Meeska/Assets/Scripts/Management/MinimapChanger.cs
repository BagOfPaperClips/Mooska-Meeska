using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinimapChanger : MonoBehaviour
{
    [SerializeField] int changeTo;
    [SerializeField] MinimapManager manager;
    [SerializeField] RespawnManager respawnManager;
    [SerializeField] TextMeshProUGUI text2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.ChangeDistrict(changeTo);
            respawnManager.ChangeDistrict(changeTo);

            if(this.tag == "Door")
        {
            if(text2.text == "Find the Door")
            {
            text2.text = "";
            this.tag = "Untagged";
            }
        }
        }
    }
}
