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
        _highlightTile = transform.GetChild(0).gameObject;
        //  GameObject highlightTile = Instantiate(_highlightTile, transform.position, Quaternion.identity);
        //highlightTile.gameObject.transform.parent = transform;
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
        // set highlight;
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
}
