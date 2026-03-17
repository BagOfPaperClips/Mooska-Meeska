using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursurShowUp : MonoBehaviour
{
    private MouseLook mouseLook;
    // Start is called before the first frame update
    void Start()
    {
        mouseLook = FindFirstObjectByType<MouseLook>();
        mouseLook.UnlockCursor();
    }

    // Update is called once per frame
    void Update()
    {
        mouseLook.UnlockCursor();
    }
}
