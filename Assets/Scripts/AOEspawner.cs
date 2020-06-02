using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEspawner : MonoBehaviour
{
    [SerializeField] private GameObject haloPRefab;
    [SerializeField] private float timeBetweenSpawns = 0.4f;
    [SerializeField] private float timetoDestroy = 4f;


    void Start()
    {
        StartCoroutine(SpawnAOE());
        StartCoroutine(Die());
    }


    private IEnumerator SpawnAOE()
    {
        for (int i= 1;i<=10; i++)
        {
            var halo = Instantiate(haloPRefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(timeBetweenSpawns);
             Destroy(halo);
        }     
    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(timetoDestroy);
        Destroy(gameObject);
    }


    
}
