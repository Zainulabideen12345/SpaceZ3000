using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField]
    [ColorUsage(true, true)]
    private Color[] starColors = new Color[] 
        { 
            new Color(1, 0.6f, 0.7f, 1),
            new Color(1, 0.6f, 1, 1), 
            new Color(0.6f, 0.6f, 1, 1), 
            new Color(1, 0.92f, 0.6f, 1f), 
            new Color(0.6f, 1, 0.6f, 1) 
        };

    [SerializeField] private float intensity = 1.2f;
    
    private readonly int[] starsByLayer = new int[] { 20, 40, 120, 200};
    private readonly float[] scaleByLayer = new float[] { 1.25f, 1f, 0.7f, 0.5f };
    private GameObject[] layers;

    private const float colouredChance = 0.5f;
    private const float minShimmerSpeed = 0.25f;
    private const float maxShimmerSpeed = 1f;

    void Start()
    {
        layers = new GameObject[starsByLayer.Length];

        var screenBounds = GetScreenRect(Camera.main);

        for(int layerIndex = 0; layerIndex < layers.Length; layerIndex++)
        {
            // Create a new Layer object
            var layerObject = new GameObject();
            layerObject.transform.parent = transform;
            layerObject.name = $"Layer {layerIndex + 1}";

            // Create stars for this layer
            for(int starIndex = 0; starIndex < starsByLayer[layerIndex]; starIndex++)
            {
                var newStarScale = scaleByLayer[layerIndex];
                var newStarColor = Random.Range(0f, 1f) < colouredChance ? starColors.GetRandom() : Color.white;
                var newStarXPos = Random.Range(screenBounds.xMin, screenBounds.xMax);
                var newStarYPos = Random.Range(screenBounds.yMin, screenBounds.yMax);
                var newStarPos = new Vector2(newStarXPos, newStarYPos);

                var newStar = Instantiate(Resources.Load("Star"), newStarPos, Quaternion.identity, layerObject.transform) as GameObject;
                newStar.transform.parent = layerObject.transform;
                newStar.transform.localScale = new Vector2(newStarScale, newStarScale);
                newStar.GetComponent<SpriteRenderer>().color = newStarColor;
                var factor = Mathf.Pow(2, intensity);
                var colorShine = new Color(newStarColor.r * factor,newStarColor.g * factor,newStarColor.b * factor);
                newStar.GetComponent<SpriteRenderer>().material.SetColor("_ColorShine", colorShine);
                newStar.GetComponent<SpriteRenderer>().material.SetColor("_ColorDefault", newStarColor);
            }
        }
    }

    private Rect GetScreenRect(Camera camera)
    {
        var maxX = camera.orthographicSize * camera.aspect;
        var maxY = camera.orthographicSize;
        var padding = -4f;

        return new Rect(-maxX + padding, -maxY + padding, 2 * (maxX - padding), 2 * (maxY - padding));
    }
}
