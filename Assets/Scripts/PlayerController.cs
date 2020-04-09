using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dashDistance = 10f;

    private Camera _camera;
    private Rigidbody2D _rigidbody;

    private Vector2 _movement;
    private Vector3 _mousePosition;

    //Dashing
    private bool _isDashing;
    [SerializeField]private float dashTime;
    private float _dashTimeLeft;
    private Vector2 _lastImagePos;
    private float _lastDash = -100f;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float distanceBetweenImages;
    [SerializeField] private float dashCooldown;
    

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
        CheckDash();
    }

    private void FixedUpdate()
    {
        MoveRigidBody();
        RotateRigidBody();
        Dash();
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
    
    private void CheckDash()
    {
        Debug.Log(Input.GetKeyDown("space") && Time.time >= (_lastDash + dashCooldown));
        if (Input.GetKeyDown("space") && Time.time >= (_lastDash + dashCooldown))
        {
           AttemptToDash();
        }
    }

    private void AttemptToDash()
    {
        _isDashing = true;
        _dashTimeLeft = dashTime;
        _lastDash = Time.time;
        
        PlayerAfterImagePool.Instance.GetFromPool();
        _lastImagePos = transform.position;
    }

    private void Dash()
    {
        if (!_isDashing) return;
        if (_dashTimeLeft <= 0) _isDashing = false;

        var dash = _movement * (dashSpeed * dashTime);
        _rigidbody.MovePosition(_rigidbody.position + dash);
        _dashTimeLeft -= Time.fixedDeltaTime;

        if (!(Mathf.Abs(Vector2.Distance(transform.position, _lastImagePos)) > distanceBetweenImages)) return;
        
        PlayerAfterImagePool.Instance.GetFromPool();
        _lastImagePos = transform.position;
    }

    private void TeleportDash()
    {
        var dash = _movement * dashDistance;
        _rigidbody.MovePosition(_rigidbody.position + dash);
        _isDashing = false;
    }

    private void RotateRigidBody()
    { 
        Vector2 mouseWorldPosition = _camera.ScreenToWorldPoint(_mousePosition);
        var lookDirection = mouseWorldPosition - _rigidbody.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }
}
