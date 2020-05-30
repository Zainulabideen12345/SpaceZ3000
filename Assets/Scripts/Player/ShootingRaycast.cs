using UnityEngine;

namespace DefaultNamespace
{
    public class ShootingRaycast
    {
        int damage = 50;
        public static void ShootSingle(Vector3 shootPosition, Vector3 shootDirection, float distance, int damage)
        {
            AudioManager.instance.Play("Pew");
            var raycast = Physics2D.Raycast(shootPosition, shootDirection, distance, LayerMask.GetMask("Enemy"));

            if (!raycast.collider) return;

            AudioManager.instance.Play("EnemyHit");
            var health = raycast.collider.gameObject.GetComponent<HealthManager>();
            health?.DealDamage(damage);
        }

        public static void ShootMultiple(Vector3 shootPosition, Vector3 shootDirection, float distance, int damage)
        {
            var raycast = Physics2D.RaycastAll(shootPosition, shootDirection, distance);

            foreach (var raycastHit2D in raycast)
            {
                if (!raycastHit2D.collider) continue;
                var health = raycastHit2D.collider.gameObject.GetComponent<HealthManager>();
                health?.DealDamage(damage);
            }
        }
    }
}