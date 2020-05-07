using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class ChangeSize : MonoBehaviour
    {
        private Vector2 _temp;
        [SerializeField] private float changingSpeed = 10f;
        [SerializeField] private int haloDamage = 200;
        [SerializeField] private float TimeToDestroy =1f;


        private IEnumerator Start()
        {
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

            
            var health = hitInfo.gameObject.GetComponent<HealthManager>();
            health?.DealDamage(haloDamage);






        }

    }
}
