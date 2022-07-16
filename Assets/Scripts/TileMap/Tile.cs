using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Tile : MonoBehaviour
{
    [SerializeField] private TileMap _tileMap;

     private GameObject _highlightTile;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!_tileMap)
        {
            Debug.LogWarning("TILE: tileMap object is not set in inspector");
        }
        _highlightTile = transform.GetChild(0).gameObject;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if (_highlightTile != null)
        {
            _highlightTile.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (_highlightTile != null)
        {
            _highlightTile.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        var centerTilePos = _tileMap.GetTileCenterPos(transform.position);
        var player = _tileMap == null? null: _tileMap.Player;
        if (player != null)
        {
            player.Move(centerTilePos);
        }
       
    }

    public virtual void ApplyEffect() { }
}