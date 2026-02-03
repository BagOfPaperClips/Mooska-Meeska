using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSystem : MonoBehaviour
{
    
    public Interactables[] traps;
    public List<Interactables> activatedTraps = new List<Interactables>();
    
    
    void Awake()
    {
        StartCoroutine(SetTraps());
    }


    IEnumerator SetTraps()
    {
        
        while (true)
        {
            
            
            activatedTraps.Clear();



            //Disables the current traps
            for(int i = 0; i < traps.Length; i++)
            {
                traps[i].gameObject.SetActive(false);
                traps[i].alert.gameObject.SetActive(false);
            }

            //sets the alerts and determines which traps will be turned on
            for(int i = 0; i < traps.Length; i++)
            {
                if (Random.Range(0, 2) == 0)
                {
                    
                    traps[i].alert.gameObject.SetActive(true);
                    activatedTraps.Add(traps[i]);
                }
            }

            // wait for seconds
            yield return new WaitForSeconds(2);

            // activate the traps
            for(int i = 0; i < activatedTraps.Count; i++)
            {
                activatedTraps[i].gameObject.SetActive(true);
            }

            
            yield return new WaitForSeconds(10);
        }
        
        
    }
}
