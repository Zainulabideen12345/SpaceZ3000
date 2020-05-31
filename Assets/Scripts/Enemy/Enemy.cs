using DefaultNamespace;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float ShootingRange = 1f;
    [SerializeField] private GameObject[] deathEffects;
    [SerializeField] private int energyAmountAdded = 20;

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
  
    private void OnDestroy()
    {
        
        for (int i = 0; i< deathEffects.Length; i++) 
        {
            Instantiate(deathEffects[i], transform.position, transform.rotation);
        }
        _player?.GetComponent<PlayerAbilitiesController>().AddEnergy(energyAmountAdded);       
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
        if (Vector2.Distance(gameObject.transform.position, _player.transform.position) < ShootingRange)
        {
            var bullet1 = Instantiate(bulletPrefab, transform.GetChild(0).transform.position, transform.rotation);
            var bullet2 = Instantiate(bulletPrefab, transform.GetChild(1).transform.position, transform.rotation);
            
            bullet1.GetComponent<Projectile>().SetVelocity(transform.up);
            bullet2.GetComponent<Projectile>().SetVelocity(transform.up);
        }
            AudioManager.instance.Play("Pew");
    }
}