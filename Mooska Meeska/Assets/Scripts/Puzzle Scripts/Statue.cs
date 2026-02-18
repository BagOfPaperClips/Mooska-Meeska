using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

public class Statue : MonoBehaviour
{
    public float rotationStep = 90f;
    public float rotationSpeed = 180f; // degrees per second
    public float tolerance = 2f;

    private Quaternion targetRotation;
    private Quaternion correctRotation;

    private bool isRotating = false;
    private bool isAligned = false;
    public StatueManager manager;
    private bool playerInRange = false;


    [Header("Material")]
    public Renderer statueRenderer;
    public Material unsolvedMaterial;
    public Material SolvedMaterial;



    void Start()
{
    int correctStep = Random.Range(0, 4);
    correctRotation = Quaternion.Euler(0f, correctStep * rotationStep, 0f);

    int startStep = Random.Range(0, 4);
    transform.rotation = Quaternion.Euler(0f, startStep * rotationStep, 0f);

    targetRotation = transform.rotation;
}

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        playerInRange = true;
    }
}

void OnTriggerExit(Collider other)
{
    if (other.CompareTag("Player"))
    {
        playerInRange = false;
    }
}

    void Update()
{
    if (Input.GetKeyDown(KeyCode.E) && !isRotating && playerInRange)
    {
        targetRotation *= Quaternion.Euler(0f, rotationStep, 0f);
        isRotating = true;
    }

    // Smooth rotation
    if (isRotating)
    {
        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            transform.rotation = targetRotation;
            isRotating = false;
            CheckAlignment();
        }
    }
}


    void CheckAlignment()
    {
        float angle = Quaternion.Angle(transform.rotation, correctRotation);

        bool nowCorrect = angle < tolerance;

        if (nowCorrect != isAligned)
        {
            isAligned = nowCorrect;


            statueRenderer.material = isAligned ? SolvedMaterial : unsolvedMaterial;

            manager.CheckStatues();

        }
    }

    public bool IsAligned()
   {
      return isAligned;
   }
}