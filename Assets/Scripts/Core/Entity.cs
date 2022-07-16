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
        protected void CalculateTileDisplacement(Vector2 targetPos)
        {
            var tiles = _tileMap.Tiles;
        }
        
        
    }
}