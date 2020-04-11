using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const int SPRITE_ANGLE_DIFF = 270;

    private Rigidbody2D _rb;
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (Vector2.Distance(_rb.transform.position, _player.position) < 3f)
        {
            Vector3 direction = _player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + SPRITE_ANGLE_DIFF;

            Debug.Log(angle);

            _rb.rotation = angle;
        }
    }
}
