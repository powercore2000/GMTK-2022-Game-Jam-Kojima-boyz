using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class Entity : MonoBehaviour
    {
        private Movement _movement;
        private TileMap _tileMap;
        public bool IsMoving => _movement.IsMoving;

        public void SetTileMap(TileMap tileMap)
        {
            _tileMap = tileMap;
        }
        private void Awake()
        {
            _movement = GetComponent<Movement>();
        }
        public virtual async void Move(Vector2 newPos)
        {
            await _movement.Move(newPos);
        }
        public int CalculateTileIndexDisplacement(Vector2 targetPos)
        {
            var tiles = _tileMap.Tiles;
            var currentTileIndex = _tileMap.GetIndexByPos(transform.position);
            var TargetTileIndex = _tileMap.GetIndexByPos(transform.position);
            var indexDispl = TargetTileIndex - currentTileIndex;
            return Mathf.Abs(indexDispl);
        }
        
        
    }
}