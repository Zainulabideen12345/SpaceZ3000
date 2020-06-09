using UnityEngine;

public class Zone : MonoBehaviour
{
    private static Zone instance;

    [Range(0f, 1f)]
    [SerializeField] private float fractionDamage;

    [SerializeField] private float damageInterval;

    [SerializeField] private float initialRadious;
    [SerializeField] private float finalRadious;
    private float currentRadious;

    [Range(0f, 1f)]
    [SerializeField] private float shrinkOnTickFraction;
    [SerializeField] private float shrinkTickRate;
    private float shrinkOnTickAmount;

    public static bool Exists => instance != null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        currentRadious = initialRadious;
        shrinkOnTickAmount = (initialRadious - finalRadious) * shrinkOnTickFraction;

        InvokeRepeating(nameof(UpdateSize), 0f, shrinkTickRate);
    }
    private void UpdateSize()
    {
        if (currentRadious > finalRadious)
        {
            currentRadious -= shrinkOnTickAmount;
        }
        else
        {
            CancelInvoke();
        }

        GetComponent<Renderer>().material.SetFloat("_Radious", currentRadious);
    }
    public static float GetFractionDamage()
    {
        return instance.fractionDamage;
    }

    public static float GetDamageInterval()
    {
        return instance.damageInterval;
    }

    public static bool IsOutside(Vector3 position)
    {
        return Vector3.Distance(position, instance.transform.position) > instance.currentRadious;
    }
}
