using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject keyPrefab;
    
    public void AddKey(KeySO key)
    {
        Debug.Log("Hark the herald");
        
        for(int i = 0; i < inventorySlots.Length; i++)
        {
            
            Debug.Log("Angel Sing");
            InventorySlot slot = inventorySlots[i];
            KeyItem itemInSlot = slot.GetComponentInChildren<KeyItem>();
            if(itemInSlot == null)
            {
                
                Debug.Log("Haleluiah");
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
    }
}
