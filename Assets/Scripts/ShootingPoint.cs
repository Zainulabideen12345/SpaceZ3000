using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class ShootingPoint : MonoBehaviour
    {
        [SerializeField] private bool isActive = false;

        public Vector3 GunEndPoint => transform.position;

        public bool IsActive => isActive;
        
    }
}