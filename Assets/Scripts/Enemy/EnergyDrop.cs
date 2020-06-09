using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrop : MonoBehaviour
{
    [SerializeField] private int energyValue = 100;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.gameObject.GetComponent<Player>();
        if (player!= null)
        {
            player.AddEnergy(energyValue);
            Destroy(gameObject);
        }
    }
}
