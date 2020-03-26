using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShootingPoint : MonoBehaviour
    {
        [SerializeField] private bool isActive = false;
        [SerializeField] private float lineRenderSpeed = 0.1f;
        private LineRenderer _lineRenderer;

        
        private float _currentLinePosition;
        private float _distance;
        private Vector3 _shootDestination, _shootPoint;

        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public Vector3 GunEndPoint => transform.position;

        public bool IsMain;

        public bool IsActive => isActive;

        public void RenderBulletTrace(Vector3 mousePosition)
        {
            _shootDestination = mousePosition;
            _shootPoint = transform.position;
            var linePositions = new Vector3[2]
            {
                transform.position,
                mousePosition
            };
            _lineRenderer.SetPositions(linePositions);
            _distance = Vector3.Distance(mousePosition, transform.position);
            _currentLinePosition = 0f;
            Invoke(nameof(ResetLineRendererPosition), .2f);
        }
        
        public void RenderBulletTraceFromDirection(Vector3 shootDirection, float timeBetweenShots, float rayCastDistance)
        {
            _shootPoint = transform.position;
            _shootDestination = _shootPoint + shootDirection * rayCastDistance;
            var linePositions = new[]
            {
                _shootPoint,
                _shootDestination
            };
            _lineRenderer.SetPositions(linePositions);
            _distance = rayCastDistance;
            _currentLinePosition = 0f;
            Invoke(nameof(ResetLineRendererPosition), timeBetweenShots - .05f);
        }

        private void Update()
        {
            if (_currentLinePosition < _distance)
            {
                _currentLinePosition += .1f / lineRenderSpeed;
                var x = Mathf.Lerp(0, _distance, _currentLinePosition);

                var pointALongLine= x * Vector3.Normalize(_shootDestination - _shootPoint) + _shootPoint;

                _lineRenderer.SetPosition(1, pointALongLine);
            }
        }

        private void ResetLineRendererPosition()
        {
            var linePositions = new[]
            {
                transform.position,
                transform.position
            };
            _currentLinePosition = _distance;
            _lineRenderer.SetPositions(linePositions);
        }
        
    }
}