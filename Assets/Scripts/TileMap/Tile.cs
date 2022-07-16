using UnityEngine;

namespace TileMap
{
    [RequireComponent(typeof(CircleCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TileMap _tileMap;
        private ILoot _loot;
        private GameObject _highlightTile;

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

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
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

        private void OnMouseDown()
        {
            var centerTilePos = _tileMap.GetTileCenterPos(transform.position);
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