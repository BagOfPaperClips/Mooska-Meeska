using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class revealMaterial : MonoBehaviour
{
    public Transform sun;
    public Renderer tRenderer;

    public LayerMask wall;

    public Material hiddenMaterial;
    public Material revealedMaterial;
    private bool isRevealed = false;

void Update()
{
    Vector3 lightDirection = -sun.forward;
    RaycastHit hit;

    bool shadowed = Physics.Raycast(transform.position, lightDirection, out hit, 100f, wall);

    if (shadowed && !isRevealed)
    {
        tRenderer.material = revealedMaterial;
        isRevealed = true;
    }
    else if (!shadowed && isRevealed)
    {
        tRenderer.material = hiddenMaterial;
        isRevealed = false;
    }
}
}