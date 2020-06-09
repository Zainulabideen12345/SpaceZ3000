using UnityEngine;

namespace DefaultNamespace
{
    public class EnemyBullet : Projectile
    {

        protected override void Start()
        {
            base.Start();
            AudioManager.Play("Pew");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Player>())
            {
                AudioManager.Play("PlayerHit");

                var health = collision.gameObject.GetComponent<HealthManager>();
                health.DealDamage(damageValue);
            }
            else if (collision.gameObject.tag == "Obstacle")
            {
                Destroy(gameObject);
            }
        }
    }
}
