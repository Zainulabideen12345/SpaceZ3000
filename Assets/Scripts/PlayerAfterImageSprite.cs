using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAfterImageSprite : MonoBehaviour
{
   private Vector2 _playerInitialPos;
   private Transform _player;

   private SpriteRenderer _spriteRenderer;
   private SpriteRenderer _playerSpriteRenderer;

   private Color _color;
   
   [SerializeField] private float activeTime = 0.1f;
   private float _timeActivated;
   private float _alpha;
   [SerializeField] private float alphaSet = 0.8f;
   [SerializeField] private float alphaMultipier = 0.85f;

   private void OnEnable()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _player = GameObject.FindGameObjectWithTag("Player").transform;
      _playerInitialPos = _player.position;
      _playerSpriteRenderer = _player.GetComponent<SpriteRenderer>();

      _alpha = alphaSet;
      _spriteRenderer.sprite = _playerSpriteRenderer.sprite;
      transform.position = _playerInitialPos;
      transform.rotation = _player.rotation;
      _timeActivated = Time.time;
   }

   private void Update()
   {
      _alpha *= alphaMultipier;
      _color = new Color(1f, 1f, 1f, _alpha);
      _spriteRenderer.color = _color;

      transform.position = _playerInitialPos;

      if (Time.time >= _timeActivated + activeTime)
      {
         PlayerAfterImagePool.Instance.AddToPool(gameObject);
      }
   }
}
