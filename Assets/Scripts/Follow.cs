using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Follow : MonoBehaviour
{
    private const int SPRITE_ANGLE_DIFF = 90;

    [SerializeField] public Transform target;

    [SerializeField] public float speed = 200f;
    [SerializeField] public float nextWaypointDistance = 3f;

    private Path _path;
    private int _currentWaypoint = 0;

    private Seeker _seeker;
    private Rigidbody2D _rb;

    // Start is called before the first frame update
    void Start()
    {
        _seeker = GetComponent<Seeker>();
        _rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .25f);
    }

    void UpdatePath()
    {
        if (_seeker.IsDone())
            _seeker.StartPath(_rb.position, target.position, OnPathComplete);
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            _path = p;
            _currentWaypoint = 0;
        }
    }

    void FixedUpdate()
    {
        if (_path == null)
            return;

        Vector2 direction = ((Vector2)_path.vectorPath[_currentWaypoint] - _rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        _rb.AddForce(force);

        float distance = Vector2.Distance(_rb.position, _path.vectorPath[_currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            _currentWaypoint++;
        }


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + SPRITE_ANGLE_DIFF;

        _rb.rotation = angle;
    }
}
