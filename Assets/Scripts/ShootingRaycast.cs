using UnityEngine;

namespace DefaultNamespace
{
    public class ShootingRaycast
    {
        public static void Shoot(Vector3 shootPosition, Vector3 shootDirection)
        {
            var raycast = Physics2D.Raycast(shootPosition, shootDirection);

            if (raycast.collider)
            {
                Debug.Log("Hit");
            }
        }
    }
}