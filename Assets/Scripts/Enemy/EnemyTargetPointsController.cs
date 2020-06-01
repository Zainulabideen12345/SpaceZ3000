using UnityEngine;

public class EnemyTargetPointsController : MonoBehaviour
{
    private static EnemyTargetPointsController controller;

    public Transform PlayerTransform;

    private const int PointsToSpawn = 10;
    private const float PointDistance = 5;

    private GameObject[] targetPoints = new GameObject[PointsToSpawn];
    float ticks;

    private int assignedPoints;

    void Start()
    {
        if(controller != null)
        {
            throw new System.Exception("Singleton reference for EnemyTargetPointsController already exists!");
        }

        controller = this;

        for (int i = 0; i < PointsToSpawn; i++)
        {
            targetPoints[i] = new GameObject();
        }
    }

    private void FixedUpdate()
    {
        ticks++;
        transform.position = PlayerTransform.position;

        for (int i = 0; i < PointsToSpawn; i++)
        {
            var point = targetPoints[i];

            var pointPosition = new Vector3(0, PointDistance, 0);
            pointPosition = Quaternion.AngleAxis((360 / PointsToSpawn * i) + ticks, Vector3.forward) * pointPosition;
            pointPosition += transform.position;
            point.transform.position = pointPosition;
            point.transform.parent = transform;

            targetPoints[i] = point;
        }
    }

    public static Transform GetUniquePoint()
    {
        var result = controller.targetPoints[controller.assignedPoints % controller.targetPoints.Length];
        controller.assignedPoints++;
        return result.transform;
    }
}
