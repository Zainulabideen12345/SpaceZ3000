using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject spawnAnimationPrefab;
    [SerializeField] private float delay;

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
        if (_enemy == null && _spawnAnimation == null)
        {
            SpawnEnemy();
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
        _enemy = Instantiate(enemyPrefab, transform.position, transform.rotation) as GameObject;
    }
}
