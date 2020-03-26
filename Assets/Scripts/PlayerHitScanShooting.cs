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
        [SerializeField] private float timeBetweenShots = .25f;
        
        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (_shootCoroutine == null)
                {
                    _shootCoroutine =  StartCoroutine(Shoot());
                }
            }
            else if(Input.GetMouseButtonUp(0))
            {
                StopCoroutine(_shootCoroutine);
                _shootCoroutine = null;
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
                yield return new WaitForSeconds(timeBetweenShots);
            }
        }

        private void ShootFromShootPoint(Vector3 mouseWorldPoint, ShootingPoint shootingPoint, ShootingPoint mainShootingPoint)
        {
            var gunPoint = shootingPoint.GunEndPoint;
            var mainGunPoint = mainShootingPoint.GunEndPoint;

            var shootPoint = mouseWorldPoint + (gunPoint - mainGunPoint);
            var shootDirection = (shootPoint - gunPoint).normalized;
            
            // shootingPoint.RenderBulletTrace(shootPoint);
            Debug.DrawLine(gunPoint, gunPoint + shootDirection * rayCastDistance, Color.black, .5f);
            shootingPoint.RenderBulletTraceFromDirection(shootDirection, timeBetweenShots, rayCastDistance);
            ShootingRaycast.Shoot(gunPoint, shootDirection, rayCastDistance);
        }
    }
}
