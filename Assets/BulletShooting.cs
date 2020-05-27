using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots = 0.25f;
    private Coroutine _shootCoroutine;
    private float _nextShotTime = -100f;
    [SerializeField] private GameObject weapon_1_Prefab;
    [SerializeField] private Transform midShooting;

    public void StartShooting()
    {
        if (_shootCoroutine == null && Time.time > (_nextShotTime + timeBetweenShots))
        {
            _shootCoroutine = StartCoroutine(Shoot());
        }
        _nextShotTime = Time.time;
    }

    public void StopShooting()
    {
        if (_shootCoroutine == null) return;

        StopCoroutine(_shootCoroutine);
        _shootCoroutine = null;
    }
    private IEnumerator Shoot()
    {
        while (true)
        {
            Instantiate(weapon_1_Prefab, midShooting.position, midShooting.rotation);

            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
