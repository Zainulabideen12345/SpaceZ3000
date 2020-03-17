using System;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHitScanShooting : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private ShootingPoint[] shootingPoints;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
                foreach (var shootingPoint in shootingPoints.Where(point => point.IsActive))
                {
                    ShootFromShootPoint(mouseWorldPoint, shootingPoint);
                }
            }
        }

        private static void ShootFromShootPoint(Vector3 mouseWorldPoint, ShootingPoint shootingPoint)
        {
            var gunEndPoint = shootingPoint.GunEndPoint;
            var shootPoint = (mouseWorldPoint - gunEndPoint).normalized;
            Debug.DrawLine(gunEndPoint, mouseWorldPoint, Color.red, .1f);
            ShootingRaycast.Shoot(shootingPoint.GunEndPoint, shootPoint);
        }
    }
}