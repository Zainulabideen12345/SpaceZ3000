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

    [SerializeField] private GameObject energyBar;
    [SerializeField] private int initialEnergy = 250;
    [SerializeField] private int maxEnergy = 500;
    private int currentEnergy;

    [SerializeField] private int haloEnergyCost = 250;

    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PlayerControls.UseUltimate.performed += ctx => StartCoroutine(UltimateMissile());
        _playerInput.PlayerControls.UseHalo.performed += ctx => UltimateHalo();
        _playerInput.PlayerControls.UseFlare.performed += ctx => StartCoroutine(Flare());

        currentEnergy = initialEnergy;
    }

    private void Update()
    {
        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        energyBar.transform.Find("Bar").localScale = new Vector3((float)currentEnergy/maxEnergy, 1f, 1f);
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
        if (currentEnergy >= haloEnergyCost)
        {
            currentEnergy -= haloEnergyCost;
            GameObject Ulti2 = Instantiate(haloPrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);
        }

    }

    private IEnumerator Flare()
    {
        for (int i = 1; i <= 3; i++)
        {
            GameObject Ulti3 = Instantiate(flarePrefab, ShootingPoint_back.position, ShootingPoint_back.rotation);
            yield return new WaitForSeconds(TimeBetweenFlares);

        }
    }

    public void AddEnergy(int energy)
    {
        currentEnergy += energy;
        if (currentEnergy > maxEnergy)
        {
            currentEnergy = maxEnergy;
        }
    }
}
