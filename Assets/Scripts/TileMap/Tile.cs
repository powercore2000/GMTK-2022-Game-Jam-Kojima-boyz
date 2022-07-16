using UnityEngine;

namespace TileMap
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TileMap _tileMap;
        private Loot _loot;
        private GameObject _highlightTile;
        // Will be entity
        private GameObject _entity;
        private SpriteRenderer _spriteRenderer;

        // Start is called before the first frame update
        private void Awake()
        {
            if (!_tileMap)
            {
                Debug.LogWarning("TILE: tileMap object is not set in inspector");
            }

            _spriteRenderer = GetComponent<SpriteRenderer>();
            _highlightTile = transform.GetChild(0).gameObject;
        }

        public void SetEntity(GameObject entity)
        {
            _entity = entity;
        }

        public GameObject GetEntity()
        {
            return _entity;
        }

        public SpriteRenderer GetSpriteRenderer()
        {
            #if UNITY_EDITOR
            _spriteRenderer = GetComponent<SpriteRenderer>();
            #endif
            return _spriteRenderer;
        }

        public void SetLoot(Loot loot)
        {
            _loot = loot;
        }

        public Loot GetLoot()
        {
            return _loot;
        }

        public void UpdateSprite(Sprite sprite)
        {
        #if UNITY_EDITOR
            _spriteRenderer = GetComponent<SpriteRenderer>();
        #endif
            _spriteRenderer.sprite = sprite;
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

        public Vector2 GetTileCenterPos()
        {
            
            var xPos = transform.position.x;
            var yPos = transform.position.y+0.25f;
            return new Vector2(xPos, yPos);
        }
        private void OnMouseDown()
        {
            var centerTilePos = GetTileCenterPos();
            var player = _tileMap == null ? null : _tileMap.Player;
            if (player != null)
            {
                player.Move(centerTilePos);
            }
        }

        public virtual void ApplyEffect()
        {
        }
    }
}