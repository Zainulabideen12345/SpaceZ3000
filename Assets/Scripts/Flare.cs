using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flare : MonoBehaviour
{
    [SerializeField] private float flareLifeTime;
    private void Start()
    {
        Destroy(gameObject, flareLifeTime);
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Kamikaze_Enemy")
        {
            Destroy(gameObject);                
        }
    }
}
