using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BillboardWorldUI : MonoBehaviour
{
   Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }


    void LateUpdate()
    {
        if(mainCamera != null)
        {
            transform.LookAt(mainCamera.transform.position +mainCamera.transform.forward);

            // Vector3 dir = transform.position - mainCamera.transform.position;
            // transform.rotation = quaternion.LookRotation(dir, Vector3.up);
        }
    }
}
