using System.Collections;
using UnityEngine;
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

    [Header("Ability Costs")]
    [SerializeField] private int haloEnergyCost = 250;
    [SerializeField] private int missileEnergyCost = 25;
    [SerializeField] private int minesEnergyCost = 75;

    private Player _player;
    private PlayerInput _playerInput;

    private void Awake()
    {
        _player = GetComponent<Player>();

        _playerInput = new PlayerInput();
        _playerInput.PlayerControls.UseUltimate.performed += ctx => UseUltimateMissile();
        _playerInput.PlayerControls.UseHalo.performed += ctx => UseUltimateHalo();
        _playerInput.PlayerControls.UseFlare.performed += ctx => StartCoroutine(Flare());
        _playerInput.PlayerControls.UseMines.performed += ctx => UseUltimateMines();
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
        if (_player.GetCurrentEnergy() >= missileEnergyCost)
        {
            _player.SpendEnergy(missileEnergyCost);
            StartCoroutine(UltimateMissile());
        }
    }
    private void UseUltimateMines()
    {
        if (_player.GetCurrentEnergy() >= minesEnergyCost)
        {
            _player.SpendEnergy(minesEnergyCost);
            StartCoroutine(Mines());
        }
    }

    private IEnumerator UltimateMissile()
    {
        for (int i = 1; i<= MissileAmount; i++)
        {
            var Ulti = Instantiate(missilePrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);
            Ulti.transform.parent = MiscellaneousObjectsController.ProjectilesHolder;

            yield return new WaitForSeconds(TimeBetweenMissiles);
        }
    }
    void UseUltimateHalo()
    {
        if (_player.GetCurrentEnergy() >= haloEnergyCost)
        {
            _player.SpendEnergy(haloEnergyCost);
            var Ulti2 = Instantiate(haloPrefab, ShootingPoint_Mid.position, ShootingPoint_Mid.rotation);
            Ulti2.transform.parent = MiscellaneousObjectsController.ProjectilesHolder;
        }
    }

    private IEnumerator Flare()
    {
        for (int i = 1; i <= 3; i++)
        {
            var Ulti3 = Instantiate(flarePrefab, ShootingPoint_back.position, ShootingPoint_back.rotation);
            Ulti3.transform.parent = MiscellaneousObjectsController.ProjectilesHolder;
            yield return new WaitForSeconds(TimeBetweenFlares);      
        }
    }
    private IEnumerator Mines()
    {
        for (int i = 1; i <=minesAmount; i++)
        {
            var Ulti4 = Instantiate(minePrefab, ShootingPoint_back.position, ShootingPoint_back.rotation);
            Ulti4.transform.parent = MiscellaneousObjectsController.ProjectilesHolder;
            yield return new WaitForSeconds(TimeBetweenMines);
        }      
    }
}
