using UnityEngine;

public class EnemyObjectsController : MonoBehaviour
{
    private static EnemyObjectsController _controller;

    public Transform enemyHolder;

    public Transform spawnerHolder;

    public Transform animationHolder;

    void Awake()
    {
        _controller = this;    
    }

    public static Transform EnemyHolder => _controller.enemyHolder;

    public static Transform SpawnerHolder => _controller.spawnerHolder;

    public static Transform AnimationHolder => _controller.animationHolder;
}
