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
            if (Input.GetMouseButton(0))
            {
                var mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

                // Obtain a reference to the main shooting point
                var mainShootingPoint = shootingPoints.Single(point => point.IsMain);

                foreach (var shootingPoint in shootingPoints.Where(point => point.IsActive))
                {
                    ShootFromShootPoint(mouseWorldPoint, shootingPoint, mainShootingPoint);
                }
            }
        }

        private static void ShootFromShootPoint(Vector3 mouseWorldPoint, ShootingPoint shootingPoint, ShootingPoint mainShootingPoint)
        {
            var gunPoint = shootingPoint.GunEndPoint;
            var mainGunPoint = mainShootingPoint.GunEndPoint;

            var shootPoint = mouseWorldPoint + (gunPoint - mainGunPoint);
            var shootDirection = (shootPoint - gunPoint).normalized;

            Debug.DrawLine(gunPoint, shootPoint, Color.red, .1f);
            ShootingRaycast.Shoot(shootingPoint.GunEndPoint, shootDirection);
        }
    }
}
