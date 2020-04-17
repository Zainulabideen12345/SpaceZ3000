using UnityEngine;

namespace DefaultNamespace
{
    public class ShootingRaycast
    {
        public static void ShootSingle(Vector3 shootPosition, Vector3 shootDirection, float distance, int damage)
        {
            var raycast = Physics2D.Raycast(shootPosition, shootDirection, distance);

            if (!raycast.collider) return;
            var health = raycast.collider.gameObject.GetComponent<ShieldHealth>();
            health?.DealDamage(damage);
        }

        public static void ShootMultiple(Vector3 shootPosition, Vector3 shootDirection, float distance, int damage)
        {
            var raycast = Physics2D.RaycastAll(shootPosition, shootDirection, distance);

            foreach (var raycastHit2D in raycast)
            {
                if (!raycastHit2D.collider) continue;
                var health = raycastHit2D.collider.gameObject.GetComponent<Health>();
                health?.DealDamage(damage);
            }
        }
    }
}