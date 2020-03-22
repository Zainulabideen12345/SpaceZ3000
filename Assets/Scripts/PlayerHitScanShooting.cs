using System;
using System.Collections;
using System.Linq;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerHitScanShooting : MonoBehaviour
    {
        private Camera _camera;
        private Coroutine _shootCoroutine;
        [SerializeField] private ShootingPoint[] shootingPoints;
        [SerializeField] private float rayCastDistance;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
               _shootCoroutine =  StartCoroutine(Shoot());
            }
            else if(Input.GetMouseButtonUp(0))
            {
                StopCoroutine(_shootCoroutine);
            }
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
                var mouseWorldPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

                // Obtain a reference to the main shooting point
                var mainShootingPoint = shootingPoints.Single(point => point.IsMain);

                foreach (var shootingPoint in shootingPoints.Where(point => point.IsActive))
                {
                    ShootFromShootPoint(mouseWorldPoint, shootingPoint, mainShootingPoint);
                }
                yield return new WaitForSeconds(.25f);
            }
        }

        private void ShootFromShootPoint(Vector3 mouseWorldPoint, ShootingPoint shootingPoint, ShootingPoint mainShootingPoint)
        {
            var gunPoint = shootingPoint.GunEndPoint;
            var mainGunPoint = mainShootingPoint.GunEndPoint;

            var shootPoint = mouseWorldPoint + (gunPoint - mainGunPoint);
            var shootDirection = (shootPoint - gunPoint).normalized;

            // Debug.DrawLine(gunPoint, shootPoint, Color.red, .1f);
            shootingPoint.RenderBulletTrace(shootPoint);
            ShootingRaycast.Shoot(gunPoint, shootDirection, rayCastDistance);
        }
    }
}
