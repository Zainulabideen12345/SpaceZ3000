using UnityEngine;

public class MiscellaneousObjectsController : MonoBehaviour
{
    private static MiscellaneousObjectsController _controller;

    public Transform projectilesHolder;

    public Transform explosionHolder;

    public Transform pickupHolder;

    void Start()
    {
        _controller = this;
    }

    public static Transform ProjectilesHolder => _controller.projectilesHolder;

    public static Transform ExplosionHolder => _controller.explosionHolder;

    public static Transform PickupHolder => _controller.pickupHolder;
}
