using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Camera _camera;
    private Rigidbody2D _rigidbody;
    
    //Movement
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float dashDistance = 10f;
    private PlayerInput _playerInput;
    private Vector2 _movement;
    private Vector2 _mousePosition;
    private bool _isMouse;

    //Dashing
    [Header("Dashing")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float distanceBetweenImages;
    [SerializeField] private float dashCooldown;
    [SerializeField]private float dashTime;
    private bool _isDashing;
    private float _dashTimeLeft;
    private Vector2 _lastImagePos;
    private float _lastDash = -100f;
    
    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PlayerControls.Move.performed += ctx => _movement = ctx.ReadValue<Vector2>();
        _playerInput.PlayerControls.Aim.performed += ctx =>
        {
            _isMouse = ctx.control.device == Mouse.current;
            var aimPos = ctx.ReadValue<Vector2>();
            if (aimPos.magnitude > 0.2f)
            {
                _mousePosition = aimPos;
            }
        };
        _playerInput.PlayerControls.Dash.performed += ctx => CheckDash();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
        _rigidbody = GetComponent<Rigidbody2D>();
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
        if (Time.time >= (_lastDash + dashCooldown))
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
        if (_isMouse)
        {
            RotateRigidBodyMouse();
        }
        else
        {
            RotateRigidBodyGamePad();
        }
    }

    private void RotateRigidBodyMouse()
    {
        var aimDirection = (Vector2) _camera.ScreenToWorldPoint(_mousePosition);
        var lookDirection = aimDirection - _rigidbody.position;
        var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }

    private void RotateRigidBodyGamePad()
    {
        var angle = Mathf.Atan2(_mousePosition.y, _mousePosition.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }
}
