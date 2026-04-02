using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorDialog : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textdoor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("DoorDialog"))
        {
            StartCoroutine(DoorText());
        }
        
    }

    private IEnumerator DoorText()
    {
        textdoor.fontSize = 85;
        textdoor.text = "There are key holes on this door,    I should find them";
        yield return new WaitForSeconds(2.5f);
        textdoor.text = "";
    }
}
