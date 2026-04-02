using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseToFloor : MonoBehaviour
{
    [SerializeField] GameObject mouse;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse.transform.position.y> 0.07f)
        {
            StartCoroutine(mousedrop());
        }
    }

    private IEnumerator mousedrop()
    {
        yield return new WaitForSeconds(1f);
        Vector3 v = new Vector3(mouse.transform.position.x, 0.07f, mouse.transform.position.z);
        mouse.transform.position = v;
    }
}
