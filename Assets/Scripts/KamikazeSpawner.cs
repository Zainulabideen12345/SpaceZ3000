using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeSpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnAnimationPrefab;
    [SerializeField] private float delay;
    [SerializeField] private int enemySpawnNumber;
    [SerializeField] private int maxEnemyNumber;
    private int minEnemyNumber = 1;

    private GameObject _enemy;
    private GameObject _spawnAnimation;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_enemy != null && _spawnAnimation == null&& minEnemyNumber<=maxEnemyNumber)
        {
           
         SpawnEnemy();
            minEnemyNumber++;
        }
    }

    private void SpawnEnemy()
    {
        SpawnAnimationPrefab();
        Invoke(nameof(SpawnEnemyPrefab), delay);
    }

    private void SpawnAnimationPrefab()
    {
        _spawnAnimation = Instantiate(spawnAnimationPrefab, transform.position, transform.rotation) as GameObject;
    }

    private void SpawnEnemyPrefab()
    {
        Destroy(_spawnAnimation);
        for (int i = 1; i <= enemySpawnNumber; i++)
        {
            _enemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
        }
    }
}
