using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    private Rigidbody2D _rb;
    private Renderer _renderer;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Debug.Log("hit!");
        }
        else if (collision.gameObject.GetComponent<Enemy>())
        {
            return;
        }

        Destroy(gameObject);
    }
}