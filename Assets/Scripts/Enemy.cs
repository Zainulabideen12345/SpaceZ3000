using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float projectileSpeed;

    private const int SPRITE_ANGLE_DIFF = 270;

    private Rigidbody2D _rb;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player");

        gameObject.AddComponent<AIDestinationSetter>();
        GetComponent<AIDestinationSetter>().target = _player.transform;

        InvokeRepeating(nameof(Shoot), .5f, 1f / attackSpeed);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(_rb.transform.position, _player.transform.position) < 3f)
        {
            Vector3 direction = _player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + SPRITE_ANGLE_DIFF;

            _rb.rotation = angle;
        }
    }

   private void Shoot()
    {
        GameObject bullet1 = Instantiate(bulletPrefab, transform.GetChild(0).transform.position, transform.rotation) as GameObject;
        GameObject bullet2 = Instantiate(bulletPrefab, transform.GetChild(1).transform.position, transform.rotation) as GameObject;

        bullet1.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;
        bullet2.GetComponent<Rigidbody2D>().velocity = transform.up * projectileSpeed;
    }
}