using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class Halo : MonoBehaviour
    {
        private Vector2 _temp;
        [SerializeField] private float changingSpeed = 10f;
        [SerializeField] private int haloDamage = 100;
        
        [SerializeField] private GameObject haloParticle;
        private float _timeToDestroy = 1f;
        private float _particleDestroy = 5f;

        private void Start()
        {
           var halo1 = Instantiate(haloParticle, transform.position, transform.rotation);
            AudioManager.instance.Play("HaloCast");
            
            Destroy(gameObject,_timeToDestroy);
            Destroy(halo1,_particleDestroy);
        }
        void Update()
        {
            _temp = transform.localScale;
            _temp.x += changingSpeed * Time.deltaTime;
            _temp.y += changingSpeed * Time.deltaTime;

            transform.localScale = _temp;

        }
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                AudioManager.instance.Play("HaloHit");
                var health = hitInfo.gameObject.GetComponent<HealthManager>();
                health?.DealDamage(haloDamage);

            }
        }

    }
}
