using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BookGuide : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI TextMesh;
    [SerializeField] private GameKeys Key = GameKeys.OpenBook;

    [Header("Defeault Key")]
    [SerializeField] private KeyCode defaultKey;
    // Start is called before the first frame update
    private void Awake()
    {
        if (TextMesh == null)
        {
            TextMesh = gameObject.GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        KeyCode boundKey = KeyBinding.GetKey(Key, defaultKey);
        TextMesh.text = "Press " + boundKey.ToString() + " For Bird Book";
    }
}
