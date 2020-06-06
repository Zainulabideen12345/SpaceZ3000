using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }
    private void LateUpdate()
    {
        if (_player != null)
        {
            Vector3 newPosition = _player.transform.position;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
    }
}
