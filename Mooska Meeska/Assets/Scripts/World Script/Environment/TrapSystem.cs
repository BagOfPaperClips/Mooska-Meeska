using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSystem : MonoBehaviour
{
    
    public Interactables[] traps;
    
    
    void Awake()
    {
        StartCoroutine(SetTraps());
    }


    IEnumerator SetTraps()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(5);



            for(int i = 0; i < traps.Length; i++)
            {
                traps[i].gameObject.SetActive(false);

                if(Random.Range(0,3) == 0)
                {
                    traps[i].alert.SetActive(true);
                    yield return new WaitForSeconds(2);
                    traps[i].gameObject.SetActive(true);
                    
                }
            }

        }
        
        
    }
}
