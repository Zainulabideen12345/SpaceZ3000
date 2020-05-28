using System;
using UnityEngine;

[Serializable]
public class Droppable
{
    public GameObject itemPrefab;
    public int dropChanceRate;
    public Droppable(GameObject itemPrefab, int dropChanceRate)
    {
        this.itemPrefab = itemPrefab;
        this.dropChanceRate = dropChanceRate;
    }
}