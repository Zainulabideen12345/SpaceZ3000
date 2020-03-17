using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Camera _camera;
    private Rigidbody2D _rigidbody;

    private Vector2 _movement;
    private Vector3 _mousePosition;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        _movement.x = Input.GetAxis("Horizontal");
        _movement.y = Input.GetAxis("Vertical");
        _mousePosition = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        MoveRigidBody();
        RotateRigidBody();
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var position = transform.position;
        var newXPosition = position.x + deltaX;
        var newYPosition = position.y + deltaY;
        position = new Vector2(newXPosition, newYPosition);
        transform.position = position;
    }

    private void MoveRigidBody()
    {
        var movement = _movement * (moveSpeed * Time.fixedDeltaTime);
        _rigidbody.MovePosition(_rigidbody.position + movement);
    }

    private void RotateRigidBody()
    { 
        Vector2 mouseWorldPosition = _camera.ScreenToWorldPoint(_mousePosition);
        var lookDirection = mouseWorldPosition - _rigidbody.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }
}
