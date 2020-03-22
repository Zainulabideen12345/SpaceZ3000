using UnityEngine;

namespace DefaultNamespace
{
    public class ShootingRaycast
    {
        public static void Shoot(Vector3 shootPosition, Vector3 shootDirection, float distance)
        {
            var raycast = Physics2D.Raycast(shootPosition, shootDirection, distance);

            if (raycast.collider)
            {
                var health = raycast.collider.gameObject.GetComponent<Health>();
                health?.DealDamage(20);
            }
        }
    }
}