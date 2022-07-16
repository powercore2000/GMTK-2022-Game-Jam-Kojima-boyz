using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TileMap _tileMap;
        private Loot.Loot _loot;
        private GameObject _highlightTile;

        [Header("HighlightedColors")]
        [SerializeField] private Color _moveColor;
        [SerializeField] private Color _hostileColor;
        
        
        // Will be entity
        private Entity _entity;
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

        public void SetEntity(Entity entity)
        {
            _entity = entity;
            _entity.transform.position = GetTileCenterPos();
        }

        public Entity GetEntity()
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

        public void SetLoot(Loot.Loot loot)
        {
            _loot = loot;
        }

        public Loot.Loot GetLoot()
        {
            return _loot;
        }


        public void UpdateHighlightColor(Color color)
        {
            _highlightTile.GetComponent<SpriteRenderer>().color = color;
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
            var indexDisplacent = _tileMap.Player.CalculateTileIndexDisplacement(_highlightTile.transform.position);
            bool isHorizontal = indexDisplacent == 1;
            bool isVertical = indexDisplacent == 5;
            bool isDiagonal = indexDisplacent == 6;
            if ( isDiagonal || isVertical || isHorizontal)
            {
                if (_highlightTile != null)
                {
                    _highlightTile.SetActive(true);
                }
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
                player.SaveDesiredDestination(centerTilePos);
            }
        }

        public virtual void ApplyEffect()
        {
        }
    }
}