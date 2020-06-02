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
        [SerializeField] private float TimeToDestroy =1f;
        [SerializeField] private GameObject haloParticle;

        private IEnumerator Start()
        {
            Instantiate(haloParticle, transform.position, transform.rotation);
            AudioManager.instance.Play("HaloCast");
            yield return new WaitForSeconds(TimeToDestroy);
            Destroy(gameObject);
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
