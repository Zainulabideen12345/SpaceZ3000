using DefaultNamespace;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{ 
    [SerializeField] private bool isUsingWeapon1;
    [SerializeField] private bool isUsingWeapon2;
    private PlayerHitScanShooting playerHitScanShooting;
    private BulletShooting bulletShooting;
    private PlayerInput _playerInput;
    
    private void Start()
    {
        playerHitScanShooting = gameObject.GetComponent<PlayerHitScanShooting>();
        bulletShooting = gameObject.GetComponent<BulletShooting>();
    }

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PlayerControls.ShootMain.performed += ctx => Shooting(true);
        _playerInput.PlayerControls.ShootMain.canceled += ctx => Shooting(false);
        _playerInput.PlayerControls.SwitchWeapon1.performed += ctx => SetWeapon1();
        _playerInput.PlayerControls.SwitchWeapon2.performed += ctx => SetWeapon2();
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Shooting(bool isShooting)
    {
        if(isUsingWeapon1 == true && isUsingWeapon2 == false)
        {
            if (isShooting)
            {
                bulletShooting?.StartShooting();
            }
            else
            {
               bulletShooting?.StopShooting();
            }
        }
         if (isUsingWeapon1 == false && isUsingWeapon2 == true)
        {
            if (isShooting)
            {
                playerHitScanShooting?.StartShooting();

            }
            else
            {
                playerHitScanShooting?.StopShooting();
            }
        }
    }

    private void SetWeapon1()
    {
        playerHitScanShooting?.StopShooting();
        isUsingWeapon1 = true; 
        isUsingWeapon2 = false;
    }
    private void SetWeapon2()
    {
        bulletShooting?.StopShooting();
        isUsingWeapon1 = false; 
        isUsingWeapon2 = true;
    }
}
