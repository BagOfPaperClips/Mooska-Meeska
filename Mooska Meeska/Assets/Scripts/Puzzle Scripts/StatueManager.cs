using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueManager : MonoBehaviour
{
   public Statue[] statues;
   private bool statuesSolved = false;

   public void CheckStatues()
   {
      if (statuesSolved)
      {
         return;
      }

      foreach(Statue statue in statues)
      {
         if (!statue.IsAligned())
         {
            return;
         }
      }

      SolveStatues();
   }

   void SolveStatues()
   {
      statuesSolved = true;

   }

   
}
