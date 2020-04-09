using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class PlayerHitScanShooting : MonoBehaviour
    {
        private Camera _camera;
        private Coroutine _shootCoroutine;
        [SerializeField] private int damage = 20;
        [SerializeField] private ShootingPoint[] shootingPoints;
        [SerializeField] private float rayCastDistance;
        [SerializeField] private float timeBetweenShots = .25f;
        
        //Input
        private PlayerInput _playerInput;
        private Vector2 _mousePosition;
        private Rigidbody2D _rigidBody;
        private bool _isMouse;

        private void Awake()
        {
            _playerInput = new PlayerInput();
            _playerInput.PlayerControls.ShootMain.performed += ctx => StartShooting();
            _playerInput.PlayerControls.ShootMain.canceled += ctx => StopShooting();
            _playerInput.PlayerControls.Aim.performed += ctx =>
            {
                _isMouse = ctx.control.device == Mouse.current;
                _mousePosition = ctx.ReadValue<Vector2>();
            }; 
        }

        private void Start()
        {
            _camera = Camera.main;
            _rigidBody = GetComponent<Rigidbody2D>();
        }
        
        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Update()
        {
            // if (Input.GetMouseButton(0))
            // {
            //     if (_shootCoroutine == null)
            //     {
            //         _shootCoroutine =  StartCoroutine(Shoot());
            //     }
            // }
            // else if(Input.GetMouseButtonUp(0))
            // {
            //     StopCoroutine(_shootCoroutine);
            //     _shootCoroutine = null;
            // }
        }

        private void StartShooting()
        {
            if (_shootCoroutine == null)
            {
                _shootCoroutine =  StartCoroutine(Shoot());
            }
        }

        private void StopShooting()
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                // var mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
                // var mouseWorldPoint = (_isMouse) ? (Vector2) _camera.ScreenToWorldPoint(_mousePosition) : _mousePosition;
                var mouseWorldPoint = _rigidBody.position;
                

                // Obtain a reference to the main shooting point
                var mainShootingPoint = shootingPoints.Single(point => point.IsMain);

                foreach (var shootingPoint in shootingPoints.Where(point => point.IsActive))
                {
                    ShootFromShootPoint(mouseWorldPoint, shootingPoint, mainShootingPoint);
                }
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }

        private void ShootFromShootPoint(Vector3 mouseWorldPoint, ShootingPoint shootingPoint, ShootingPoint mainShootingPoint)
        {
            var gunPoint = shootingPoint.GunEndPoint;
            var mainGunPoint = mainShootingPoint.GunEndPoint;

            var shootPoint = mouseWorldPoint + (gunPoint - mainGunPoint);
            Vector2 shootDirection = -(shootPoint - gunPoint).normalized;
            
            // shootingPoint.RenderBulletTrace(shootPoint);
            shootingPoint.RenderBulletTraceFromDirection(shootDirection, timeBetweenShots, rayCastDistance);
            ShootingRaycast.ShootSingle(gunPoint, shootDirection, rayCastDistance, damage);
        }
    }
}
