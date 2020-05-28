using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "health/RegenerativeHealthConfig")]
public class RegenerativeHealthConfig : BaseHealthConfig
{
   public float regenerateCooldown;
   public int regenerateAmount;

   public override BaseHealth CreateHealth()
   {
      return new RegenerativeHealth(health, healthBarColor, regenerateCooldown, regenerateAmount);
   }
}
