using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] float dropProbability;
    [SerializeField] private List<Droppable> availableDrops;
    private void OnDestroy()
    {
        if (Random.Range(0f, 1) < dropProbability)
        {
            int total = availableDrops.ConvertAll(e => e.dropChanceRate).Sum();
            int randomNumber = Random.Range(0, total);

            foreach (Droppable d in availableDrops)
            {
                if (randomNumber < d.dropChanceRate)
                {
                    Drop(d);
                    break;
                }
                else
                {
                    randomNumber -= d.dropChanceRate;
                }
            }
        }
    }

    private void Drop (Droppable d)
    {
        Instantiate(d.itemPrefab, gameObject.transform.position, Quaternion.identity);
    }
}
