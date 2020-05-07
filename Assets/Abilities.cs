using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Abilities : MonoBehaviour
{
    public Transform ShootingPoint_Mid;
    public GameObject missilePrefab;
    private PlayerInput _playerInput;
    public GameObject haloPrefab;
    


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
        for (int i = 0; i <= 9; i++)
        {
            GameObject Ulti = Instantiate(missilePrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);

            yield return new WaitForSeconds(1);
        }

    }
    void UltimateHalo()
    {
        GameObject Ulti2 = Instantiate(haloPrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);
    }








}
