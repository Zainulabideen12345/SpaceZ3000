using UnityEngine;

public class StarController : MonoBehaviour
{
    private readonly float[] distanceMultipliers = new float[] { 0.04f, 0.03f, 0.02f, 0.01f };

    void Update()
    {
        var parentPosition = transform.parent.position;

        var layerCount = transform.childCount;

        for(int i = 0; i < layerCount; i++)
        {
            var newStarPos = parentPosition * -distanceMultipliers[i];
            newStarPos.z = 15;
            transform.GetChild(i).transform.localPosition = newStarPos;
        }
    }
}
