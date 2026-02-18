using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;


public class Statue : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationStep = 90f;
    public float rotationSpeed = 180f;

    private Quaternion targetRotation;
    private bool isRotating = false;
    private int currentIndex = 0;

    [Header("Player Interaction")]
    public bool playerInRange = false;
    public StatueManager manager;

    [Header("Materials (Order Matches Rotation)")]
    public Renderer statueRenderer;
    public Material[] rotationMaterials; // Assign in Inspector

    [Header("Correct Colour Index")]
    public int correctIndex;  // Set per statue in Inspector


    void Start()
    {
        // Pick a random starting index
        currentIndex = Random.Range(0, rotationMaterials.Length);

        transform.rotation = Quaternion.Euler(0f, currentIndex * rotationStep, 0f);
        targetRotation = transform.rotation;

        // Set initial material
        statueRenderer.material = rotationMaterials[currentIndex];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }

    void Update()
    {
        HandleInput();
        HandleRotation();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && !isRotating)
        {
            // Advance index
            currentIndex = (currentIndex + 1) % rotationMaterials.Length;

            // Set target rotation
            targetRotation = Quaternion.Euler(0f, currentIndex * rotationStep, 0f);

            // Immediately update material
            statueRenderer.material = rotationMaterials[currentIndex];

            // Start rotating
            isRotating = true;
        }
    }

    void HandleRotation()
    {
        if (!isRotating)
            return;

        transform.rotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime
        );

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
        {
            transform.rotation = targetRotation;
            isRotating = false;

            // Notify manager after rotation
            if (manager != null)
                manager.CheckStatues();
        }

        
    }

    // Called by StatueManager
    public bool IsCorrectColour()
    {
        return currentIndex == correctIndex;
    }
}
