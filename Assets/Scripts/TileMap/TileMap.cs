using System;
using System.Collections.Generic;
using System.Linq;
using Movement;
using UnityEngine;

namespace TileMap
{
    public class TileMap : MonoBehaviour
    {
        private readonly Vector2 Offset = new Vector2(0.418f, -0.237f); 
        private int _width = 5;
        private int _height = 5;
        [SerializeField] private Player _player;
        [SerializeField] private Tile groundTilePrefab;
        [SerializeField] private Tile spikeTilePrefab;
        [SerializeField] private Tile fireTilePrefab;
        [SerializeField] private Tile iceTilePrefab;
        
        [Header("Roll 4 Settings")]
        [SerializeField] private int amountOfEnemiesOnRoll4;
        [Header("Roll 3 Settings")]
        [SerializeField] private int amountOfEnemiesOnRoll3;
        
        [Tooltip("Uniform distribution of hazards")]
        [SerializeField][Range(0, 1)] private float probabilityOfTileIsHazard;
       
        
        [Header("Roll 2 Settings")] 
        [SerializeField][Range(0, 1)]
        private float probabilityOfBoss;
        
        [Header("Roll 1 Settings")] 
        [SerializeField][Range(0, 1)]
        private float probabilityOfMimic;
        [SerializeField][Range(0, 1)]
        private float probabiltyOfTileIsOnFire;
        

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

        
        // might use polymorphism to get rid of switch
        public void GenerateMap(int rollAmount)
        {
          Debug.Log(rollAmount);
            switch (rollAmount)
            {
                case 1 :
                   GenerateMiniBossOrMimicWithFire(probabilityOfMimic,probabiltyOfTileIsOnFire);
                    break;
                case 2 :
                    GenerateMiniBoosOrMimic(probabilityOfBoss);
                    break;
                case 3 :
                    GenerateEnemiesWithHazards(amountOfEnemiesOnRoll3, probabilityOfTileIsHazard);
                    break;
                case 4 :
                    GenerateRoomWithSmallEnemy(amountOfEnemiesOnRoll4);
                    break;
                case 5 :
                    GenerateRoomWithSmallEnemy(1);
                    break;
                case 6 :
                    GenerateLootRoom();
                    break;
                default: break;
            }
        }

        private void GenerateLootRoom()
        {
            
        }
        
        private void GenerateEnemiesWithHazards(int amountOfEnemies, float probabilityOfTileIsHazard){}
        
        private void GenerateRoomWithSmallEnemy(int amountOfEnemies)
        {
            
        }

        private void GenerateMiniBoosOrMimic(float probabilityOfBoss)
        {
            
        }

        private void GenerateMiniBossOrMimicWithFire(float probabilityOfMimic,float probabiltyOfTileIsOnFire)
        {
            #if UNITY_EDITOR
            _tiles = GetComponentsInChildren<Tile>().ToList();
            #endif


            var randomValueMimic = GetRandomValue();
            if (randomValueMimic < probabilityOfMimic)
            {
                // got mimic
            }
            else
            {
                // got boss
            }
            // generate new TileMap
            for ( int i = 0; i< _tiles.Count; i++)
            {

                if (GetRandomValue() < probabiltyOfTileIsOnFire)
                {
                    _tiles[i].UpdateSprite(fireTilePrefab.GetComponent<SpriteRenderer>().sprite);
                    _tiles[i] = fireTilePrefab.GetComponent<Tile>();
                }
                
            }

        }


        private float GetRandomValue()
        {
          return UnityEngine.Random.Range(0, 1f);
          
        }
        private int GetRandomIndex()
        {
            var count = _tiles.Count;
            var value = UnityEngine.Random.Range(0, count);
            return value;
        }

        private Tile GetRandomTile()
        {
            var randomIndex = GetRandomIndex();
            var tile = _tiles[randomIndex];
            return tile;
        }
    }
}