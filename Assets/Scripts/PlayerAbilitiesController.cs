using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint_Mid;
    [SerializeField] private Transform ShootingPoint_back;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject haloPrefab;
    [SerializeField] private GameObject flarePrefab;
    [SerializeField] private int MissileAmount;
    [SerializeField] private float TimeBetweenMissiles = 1f;
    [SerializeField] private float TimeBetweenFlares = 0.5f;

    private PlayerInput _playerInput;



    private void Awake()
    {

        _playerInput = new PlayerInput();
        _playerInput.PlayerControls.UseUltimate.performed += ctx => StartCoroutine(UltimateMissile());
        _playerInput.PlayerControls.UseHalo.performed += ctx => UltimateHalo();
        _playerInput.PlayerControls.UseFlare.performed += ctx => StartCoroutine(Flare());

    }


    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }
    

    private IEnumerator UltimateMissile()
    {
        for (int i = 1;i<= MissileAmount;i++)
        {
            GameObject Ulti = Instantiate(missilePrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);

            yield return new WaitForSeconds(TimeBetweenMissiles);
        }

    }
    void UltimateHalo()
    {
        GameObject Ulti2 = Instantiate(haloPrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);
    }

    private IEnumerator Flare()
    {
        for (int i = 1; i <= 3; i++)
        {
            GameObject Ulti3 = Instantiate(flarePrefab, ShootingPoint_back.position, ShootingPoint_back.rotation);
            yield return new WaitForSeconds(TimeBetweenFlares);

        }
    }
}
