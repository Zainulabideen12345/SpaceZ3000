using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class BulletShooting : MonoBehaviour
{
    [SerializeField] private float timeBetweenShots = 0.25f;
    private Coroutine _shootCoroutine;
    private float _nextShotTime = -100f;
    [SerializeField] private GameObject playerBullet;
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
            var bullet = Instantiate(playerBullet, midShooting.position, midShooting.rotation);
            bullet.transform.parent = MiscellaneousObjectsController.ProjectilesHolder;

            bullet.GetComponent<Projectile>().SetVelocity(transform.up);

            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}
