using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    
    public void AddKey(KeyItem key)
    {
        for(int i = 0; i > inventorySlots.Length; i++)
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

    void SpawnNewKey(KeyItem key, InventorySlot inventory)
    {
        
    }
}
