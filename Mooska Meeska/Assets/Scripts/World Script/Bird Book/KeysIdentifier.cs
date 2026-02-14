using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeysIdentifier : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI TextMesh;
    [SerializeField] private KeyCode Key = KeyCode.K;

    [Header ("Change Rate")]
    [SerializeField] private float changeRatePerSecond = 5f;

    [Header("DEBUG")]
    [SerializeField] private float currentValueR = 0f;
    [SerializeField] private float currentValueG = 0f;
    [SerializeField] private float currentValueB = 0f;
    [SerializeField] private float currentValueA = 0f;

    private Color initialColor;
    private bool revert;

    // Start is called before the first frame update
    private void Awake()
    {
        if (TextMesh == null)
        {
            TextMesh = gameObject.GetComponent<TextMeshProUGUI>();
        }

        if (TextMesh != null)
        {
            initialColor = TextMesh.color;
        }

        revert = false;

        currentValueR = TextMesh.color.r * 255f;
        currentValueG = TextMesh.color.g * 255f;
        currentValueB = TextMesh.color.b * 255f;
        currentValueA = TextMesh.color.a * 255f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Key))
        {
            Debug.Log("Pressed: " + Key);
            TextMesh.color = Color.red;
            revert = true;
        }

        if (revert)
        {

            float t = changeRatePerSecond * Time.unscaledDeltaTime;
            TextMesh.color = Color.Lerp(TextMesh.color, initialColor, t);
        }
    }

    public void keyButton()
    {
        TextMesh.color = Color.red;
        revert = true;
    }
}
