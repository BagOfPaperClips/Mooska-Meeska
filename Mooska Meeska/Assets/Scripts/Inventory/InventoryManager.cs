using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject keyPrefab;

    [Header("Inventory")]
    public int redKey = 0;
    public int greenKey = 0;
    public int yellowKey = 0;
    public int blueKey = 0;

    
    public void AddKey(KeySO key)
    {
        
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            
            InventorySlot slot = inventorySlots[i];
            KeyItem itemInSlot = slot.GetComponentInChildren<KeyItem>();
            if(itemInSlot == null)
            {
                
                SpawnNewKey(key, slot);
                return;
            }
        }
    }

    void SpawnNewKey(KeySO key, InventorySlot slot)
    {
        GameObject newKeyObject = Instantiate(keyPrefab, slot.transform);
        KeyItem keyItem = newKeyObject.GetComponent<KeyItem>();
        keyItem.InitializeKey(key);

        string colour = key.color;

        switch (colour)
        {
            case("Red"):
            redKey++;
            break;
            case("Blue"):
            blueKey++;
            break;
            case("Yellow"):
            yellowKey++;
            break;
            case("Green"):
            greenKey++;
            break;


        }

        Debug.Log("you have aquired the "+colour+" key");
    }
}
