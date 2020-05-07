using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class changeSize : MonoBehaviour
    {
        Vector2 temp;
        public float changingSpeed = 10f;
        public int haloDamage = 200;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }


        void Update()
        {
            temp = transform.localScale;
            temp.x += changingSpeed * Time.deltaTime;
            temp.y += changingSpeed * Time.deltaTime;

            transform.localScale = temp;

        }
        private void OnTriggerEnter2D(Collider2D hitInfo)
        {

            Enemy enemy = hitInfo.gameObject.GetComponent<Enemy>();
            var health = hitInfo.gameObject.GetComponent<HealthManager>();
            health?.DealDamage(haloDamage);






        }

    }
}
