using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineMover : MonoBehaviour
{
    [SerializeField] Transform modelRoot;  // assign this in the prefab

    public void SetModel(GameObject modelPrefab)
    {
        foreach (Transform child in modelRoot)
            Destroy(child.gameObject);

        GameObject model = Instantiate(modelPrefab, modelRoot);
        model.transform.localPosition = Vector3.zero;
        model.transform.localRotation = Quaternion.identity;
        model.transform.localScale = Vector3.one;
    }
}
