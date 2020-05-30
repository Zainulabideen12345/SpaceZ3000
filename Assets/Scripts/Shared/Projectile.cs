using UnityEngine;

namespace DefaultNamespace
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] protected int damageValue;
        [SerializeField] private int moveSpeed = 20;
    
        [SerializeField] 
        [ColorUsage(true, true)]
        private Color laserColor;
        
        private Renderer _renderer;
        private static readonly int LaserColor = Shader.PropertyToID("_LaserColor");

        protected virtual void Start()
        {
            _renderer = gameObject.GetComponent<Renderer>();
            var spriteRender = gameObject.GetComponent<SpriteRenderer>();
            spriteRender.material.SetColor(LaserColor, laserColor);
        }

        private void Update()
        {
            if (!_renderer.isVisible)
            {
                Destroy(gameObject);
            }
        }

        public void SetVelocity(Vector2 direction)
        {
            GetComponent<Rigidbody2D>().velocity = direction * moveSpeed;
        }
    }
}