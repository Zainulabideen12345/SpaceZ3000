using System;
using System.Collections;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerAbilitiesController : MonoBehaviour
{
    [SerializeField] private Transform ShootingPoint_Mid;
    [SerializeField] private Transform ShootingPoint_back;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private GameObject haloPrefab;
    [SerializeField] private GameObject flarePrefab;
    [SerializeField] private GameObject minePrefab;

    [SerializeField] private int MissileAmount;
    [SerializeField] private int minesAmount = 3;

    [Header("Ability Timings")]
    [SerializeField] private float TimeBetweenMissiles = 1f;
    [SerializeField] private float TimeBetweenFlares = 0.5f;
    [SerializeField] private float TimeBetweenMines = 0.5f;

    [Header("Energy")]
    [SerializeField] private Image energyLevelBar;
    [SerializeField] private int initialEnergy = 300;
    [SerializeField] private int maxEnergy = 500;
    private int currentEnergy;

    [Header("Ability Costs")]
    [SerializeField] private int haloEnergyCost = 250;
    [SerializeField] private int missileEnergyCost = 25;
    [SerializeField] private int minesEnergyCost = 75;
    
    private PlayerInput _playerInput;

    private void Awake()
    {
        _playerInput = new PlayerInput();
        _playerInput.PlayerControls.UseUltimate.performed += ctx => UseUltimateMissile();
        _playerInput.PlayerControls.UseHalo.performed += ctx => UseUltimateHalo();
        _playerInput.PlayerControls.UseFlare.performed += ctx => StartCoroutine(Flare());
        _playerInput.PlayerControls.UseMines.performed += ctx => UseUltimateMines();



        currentEnergy = initialEnergy;
    }

    private void Update()
    {
        UpdateEnergyBar();
    }

    private void UpdateEnergyBar()
    {
        energyLevelBar.transform.localScale = new Vector3((float)currentEnergy/maxEnergy, 1f, 1f);
    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    private void UseUltimateMissile()
    {
        if (currentEnergy >= missileEnergyCost)
        {
            currentEnergy -= missileEnergyCost;
            StartCoroutine(UltimateMissile());
        }
    }
    private void UseUltimateMines()
    {
        if (currentEnergy >= minesEnergyCost)
        {
            currentEnergy -= minesEnergyCost;
            StartCoroutine(Mines());
        }
    }

    private IEnumerator UltimateMissile()
    {
        for (int i = 1; i<= MissileAmount; i++)
        {
            var Ulti = Instantiate(missilePrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);

            yield return new WaitForSeconds(TimeBetweenMissiles);
        }
    }
    void UseUltimateHalo()
    {
        if (currentEnergy >= haloEnergyCost)
        {
            currentEnergy -= haloEnergyCost;
            var Ulti2 = Instantiate(haloPrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);
        }
    }

    private IEnumerator Flare()
    {
        for (int i = 1; i <= 3; i++)
        {
            var Ulti3 = Instantiate(flarePrefab, ShootingPoint_back.position, ShootingPoint_back.rotation);
            yield return new WaitForSeconds(TimeBetweenFlares);      
        }
    }
    private IEnumerator Mines()
    {
        for (int i = 1; i <=minesAmount; i++)
        {
            var Ulti4 = Instantiate(minePrefab, ShootingPoint_back.position, ShootingPoint_back.rotation);
            yield return new WaitForSeconds(TimeBetweenMines);
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
