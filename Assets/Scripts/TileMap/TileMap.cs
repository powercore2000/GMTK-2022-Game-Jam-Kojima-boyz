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

    private void Awake()
    {
        _tiles = GetComponentsInChildren<Tile>().ToList();
    }

    void Start()
    {
      
    }

    
}