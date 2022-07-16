using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileMap : MonoBehaviour
{
    private readonly Vector2 Offset = new Vector2(0.418f, -0.237f); 
    private int _width = 5;
    private int _height = 5;
    [SerializeField] private Player _player;
    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private GameObject spikeTilePrefab;
    [SerializeField] private GameObject fireTilePrefab;
    [SerializeField] private GameObject iceTilePrefab;
    private List<Tile> _tiles = new List<Tile>();
    public Player Player => _player;
    private void Awake()
    {
        _tiles = GetComponentsInChildren<Tile>().ToList();
    }

    public Vector2 GetTileCenterPos(Vector2 tilePos)
    {
        var xPos = tilePos.x;
        var yPos = tilePos.y+0.25f;
        return new Vector2(xPos, yPos);
    }
    void Start()
    {
      
    }

    public void SetTilesHighlighted(Vector2 targetTile)
    {
        // might be 2 routes to 1 tile
        
    }

    
}