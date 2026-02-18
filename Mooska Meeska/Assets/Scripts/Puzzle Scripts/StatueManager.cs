using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatueManager : MonoBehaviour
{
    [Header("All Statues in Scene")]
    public Statue[] statues;

    private bool statuesSolved = false;

    public void CheckStatues()
    {
        if (statuesSolved)
            return;

        // Check if every statue is correct
        foreach (Statue statue in statues)
        {
            if (!statue.IsCorrectColour())
                return;
        }

        SolveStatues();
    }

    void SolveStatues()
    {
        statuesSolved = true;
        Debug.Log("Puzzle Solved!");
        // Add any additional logic here (like opening doors, triggering effects, etc.)
    }
}
