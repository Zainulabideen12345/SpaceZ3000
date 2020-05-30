using UnityEngine;

public class EnemyTargetPointsController : MonoBehaviour
{
    public Transform PlayerTransform;

    private const int PointsToSpawn = 10;
    private const float PointDistance = 5;

    private GameObject[] targetPoints = new GameObject[PointsToSpawn];

    void Start()
    {
        transform.position = PlayerTransform.position;

        for (int i = 0; i < PointsToSpawn; i++)
        {
            var point = new GameObject();

            var pointPosition = new Vector3(0, PointDistance, 0);
            pointPosition = Quaternion.AngleAxis(360 / PointsToSpawn * i, Vector3.forward) * pointPosition;
            pointPosition += transform.position;
            point.transform.position = pointPosition;
            point.transform.parent = transform;

            targetPoints[i] = point;
        }
    }

    void Update()
    {
        transform.position = PlayerTransform.position;
    }
}
