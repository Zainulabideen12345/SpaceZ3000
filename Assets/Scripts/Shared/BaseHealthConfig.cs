using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[CreateAssetMenu(menuName = "health/BaseHealthConfig")]
public class BaseHealthConfig : ScriptableObject
{
   public int health;
   public Color healthBarColor;

   public virtual BaseHealth CreateHealth()
   {
      return new BaseHealth(health, healthBarColor);
   }
}
