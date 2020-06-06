using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    [SerializeField] float dropProbability;
    [SerializeField] private List<Droppable> availableDrops;
    [SerializeField] private int maxMoneyAmount;
    [SerializeField] private GameObject coinPrefab;
    private void OnDestroy()
    {
        DropMoney();
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

    private void DropMoney()
    {
        int randomNumb = Random.Range(1,maxMoneyAmount);

        for(int i =1;i<=randomNumb;i++)
        {
            var money = Instantiate(coinPrefab, transform.position, transform.rotation);
            money.transform.parent = MiscellaneousObjectsController.PickupHolder;
        }
    }

    private void Drop (Droppable d)
    {
        var drop = Instantiate(d.itemPrefab, gameObject.transform.position, Quaternion.identity);
        drop.transform.parent = MiscellaneousObjectsController.PickupHolder;
    }
}
