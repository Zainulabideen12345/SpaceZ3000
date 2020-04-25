using System.Collections.Generic;
using UnityEngine;

public class EnemyShieldGenerator : MonoBehaviour
{
    [SerializeField] private GameObject shieldPrefab;

    private List<GameObject> _shields = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        AddShieldsToNewEnemies();
        UpdateShields();
    }

    private void AddShieldsToNewEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies){
            if (!enemy.GetComponent<Health>().HasShield())
            {
                _shields.Add(Instantiate(shieldPrefab, enemy.transform));
            }
        }
    }

    private void OnDestroy()
    {
        foreach (GameObject shield in _shields)
        {
            Destroy(shield);
        }
    }

    private void UpdateShields()
    {
        foreach (GameObject shield in _shields)
        {
            LineRenderer line = shield.GetComponent<LineRenderer>();
            line.SetPosition(0, transform.position);
            line.SetPosition(1, shield.transform.position);
        }
    }
}
