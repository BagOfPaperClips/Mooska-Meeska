using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;


public class Statue : MonoBehaviour
{
    [Header("Rotation Settings")]
    public float rotationStep = 90f;      // How much to rotate each press
    public float rotationSpeed = 180f;    // Rotation speed in degrees/sec

    private Quaternion targetRotation;
    private bool isRotating = false;

    [Header("Player Interaction")]
    public bool playerInRange = false;

    void Start()
    {
        // Set initial rotation
        targetRotation = transform.rotation;
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
            // Rotate by rotationStep on Y-axis
            targetRotation = transform.rotation * Quaternion.Euler(0f, rotationStep, 0f);
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

        if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
        {
            transform.rotation = targetRotation;
            isRotating = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
