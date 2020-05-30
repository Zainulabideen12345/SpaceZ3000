using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DefaultNamespace
{
    public class PlayerHitScanShooting : MonoBehaviour
    {
        private Coroutine _shootCoroutine;
        [SerializeField] private int damage = 20;
        [SerializeField] private ShootingPoint[] shootingPoints;
        [SerializeField] private float rayCastDistance;
        [SerializeField] private float timeBetweenShots = .25f;    
        private Rigidbody2D _rigidBody;
        private float _nextShotTime = -100f;

        private void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }     
        public void StartShooting()
        {
            if (_shootCoroutine == null && Time.time > (_nextShotTime + timeBetweenShots))
            {
                _shootCoroutine =  StartCoroutine(Shoot());
            }
            _nextShotTime = Time.time;
        }

        public void StopShooting()
        {
            if(_shootCoroutine == null) return;
            
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }

        private IEnumerator Shoot()
        {
            while (true)
            {
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
            
            shootingPoint.RenderBulletTraceFromDirection(shootDirection, timeBetweenShots, rayCastDistance);
            ShootingRaycast.ShootSingle(gunPoint, shootDirection, rayCastDistance, damage);
        }
    }
}
