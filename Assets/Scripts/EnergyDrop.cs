using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrop : MonoBehaviour
{
    [SerializeField] private int energyValue = 100;
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.GetComponent<Player>() != null)
        {
            var playerAbilitiesController = hitInfo.gameObject.GetComponent<PlayerAbilitiesController>();
            playerAbilitiesController?.AddEnergy(energyValue);
            Destroy(gameObject);
        }
    }
}
