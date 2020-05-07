using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint_Mid;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject haloPrefab;
    [SerializeField] private int MissileAmount;
    [SerializeField] private float TimeBetweenMissiles = 1f;

    private PlayerInput _playerInput;



    private void Awake()
    {

        _playerInput = new PlayerInput();
        _playerInput.PlayerControls.UseUltimate.performed += ctx => StartCoroutine(UltimateMissile());
        _playerInput.PlayerControls.UseHalo.performed += ctx => UltimateHalo();

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
        for (MissileAmount = 1; MissileAmount <= 9; MissileAmount++)
        {
            GameObject Ulti = Instantiate(missilePrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);

            yield return new WaitForSeconds(TimeBetweenMissiles);
        }

    }
    void UltimateHalo()
    {
        GameObject Ulti2 = Instantiate(haloPrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);
    }








}
