using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const int SPRITE_ANGLE_DIFF = 90;

    [SerializeField] private float moveSpeed = 4f;

    private Transform _player;
    private Rigidbody2D _rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidBody = this.GetComponent<Rigidbody2D>();
        _player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector3 direction = _player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + SPRITE_ANGLE_DIFF;

        _rigidBody.rotation = angle;

        direction.Normalize();
        _rigidBody.MovePosition(transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}