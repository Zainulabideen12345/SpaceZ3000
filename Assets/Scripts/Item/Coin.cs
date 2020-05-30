using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float speed = 40;
    [SerializeField] private int rotateSpeed = 400;
    [SerializeField] private int moneyAmount = 10;
    [SerializeField] private float timeBeforeFlies = 1f;
    private BoxCollider2D _collider;
    private Transform _target;
    void Start()
    {
       _collider = GetComponent<BoxCollider2D>();
        _collider.isTrigger = false;

        StartCoroutine(GetTarget());
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {     
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().AddCoins(moneyAmount);          
            Destroy(gameObject);
        }
    }

    private IEnumerator GetTarget()
    {
        yield return new WaitForSeconds(timeBeforeFlies);
        _collider.isTrigger = true;        
        _target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
}
