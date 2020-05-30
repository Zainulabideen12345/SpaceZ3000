using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerBullet : Projectile
    {

        protected override void Start()
        {
            base.Start();
            AudioManager.instance.Play("PlayerRocket"); 
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Enemy>())
            {
                AudioManager.instance.Play("EnemyHit");

                var health = collision.gameObject.GetComponent<HealthManager>();
                health.DealDamage(damageValue);
                Destroy(gameObject);
            }
            else if (collision.gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
