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
        [SerializeField] private Entity _player;

        [Header("Tiles")] 
                
        // can be made list
        [SerializeField] private Tile groundTilePrefab;
        [SerializeField] private Tile spikeTilePrefab;
        [SerializeField] private Tile fireTilePrefab;
        [SerializeField] private Tile iceTilePrefab;
        

        [Header("Loot")]
        // can be made list
        [SerializeField] private Loot _mimic;
        [SerializeField] private Loot _speedPotion;
        [SerializeField] private Loot _healthPotion;
        [SerializeField] private Loot _weaponBonus;

        
        [Header("Enemies")] 
        // for now just gameobject
        [SerializeField] private GameObject enemyStub;
        
        [Header("Roll 6 Settings")]
        [SerializeField][Range(0, 1)]
        private float _probabilityOfLoot;
        
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
        public Entity Player => _player;
        private void Awake()
        {
            _tiles = GetComponentsInChildren<Tile>().ToList();
        }

        

        public void SetTilesHighlighted(Vector2 targetTile)
        {
            // might be 2 routes to 1 tile
        
        }

        
        // might use polymorphism to get rid of switch
        public void GenerateMap(int rollAmount)
        {
        #if UNITY_EDITOR
            _tiles = GetComponentsInChildren<Tile>().ToList();
        #endif
          Debug.Log(rollAmount);
            switch (rollAmount)
            {
                case 1 :
                   GenerateMiniBossOrMimicWithFire(probabilityOfMimic,probabiltyOfTileIsOnFire);
                    break;
                case 2 :
                    GenerateMiniBoosOrMimic(1-probabilityOfBoss);
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
                    GenerateLootRoom(_probabilityOfLoot);
                    break;
                default: break;
            }
        }

        private void GenerateLootRoom(float probabilityOfLoot)
        {
            for (int i = 0; i < _tiles.Count; i++)
            {
                var randomValue = GetRandomValue();
                if (randomValue > probabilityOfLoot) return;
                
                if (randomValue < 0.25f)
                {
                    SpawnLoot(_tiles[i],_tiles[i].GetTileCenterPos(),  _healthPotion);
                }
                else if (randomValue > 0.5f)
                {
                    SpawnLoot(_tiles[i],_tiles[i].GetTileCenterPos(),  _speedPotion);
                }
                else if (randomValue > 0.75f)
                {
                    SpawnLoot(_tiles[i],_tiles[i].GetTileCenterPos(),  _mimic);
                }
                else
                {
                    SpawnLoot(_tiles[i],_tiles[i].GetTileCenterPos(),  _weaponBonus);
                }
            }
        }
        
        private void GenerateEnemiesWithHazards(int amountOfEnemies, float probabilityOfTileIsHazard)
        {
            for (int i = 0; i < amountOfEnemies; i++)
            {
                var randomTile = GetRandomTile();
                var tilePos = (Vector2) randomTile.transform.position;
                var enemy = Instantiate(enemyStub, randomTile.GetTileCenterPos(), Quaternion.identity); 
                randomTile.SetEntity(enemy);
            }

            GenerateMapWithRandomHazards(probabilityOfTileIsHazard);
        }

        private void GenerateMapWithRandomHazards(float probabilityOfTileIsHazard)
        {
            for (int i = 0; i < _tiles.Count; i++)
            {
                var randomValue = GetRandomValue();
                if (randomValue < probabilityOfTileIsHazard)
                {
                    randomValue = GetRandomValue();
                    var diff = 1 - randomValue;
                    if (diff > 0.3f)
                    {
                        UpdateTile(_tiles[i],  iceTilePrefab);
                    }
                    else if (diff > 0.6f)
                    {
                        UpdateTile(_tiles[i],  spikeTilePrefab);
                    }
                    else
                    {
                        UpdateTile(_tiles[i],  fireTilePrefab);
                    }
                }
            }
        }

        private void GenerateRoomWithSmallEnemy(int amountOfEnemies)
        {
            for (int i = 0; i < amountOfEnemies; i++)
            {
                var randomTile = GetRandomTile();
                var tilePos = (Vector2) randomTile.transform.position;
                SpawnEnemy(randomTile,tilePos,enemyStub);
            }
        }

        private void GenerateMiniBoosOrMimic(float probabilityOfMimic)
        {

            
            var randomValueMimic = GetRandomValue();
            var randomTile = GetRandomTile();
            var tilePos = (Vector2) randomTile.transform.position;
            if (randomValueMimic < probabilityOfMimic)
            {
                // got mimic
                SpawnLoot(randomTile, tilePos, _mimic);
            }
            else
            {
                SpawnEnemy(randomTile, tilePos,enemyStub);
                // got boss
            }
        }

        private void SpawnLoot(Tile randomTile, Vector2 tilePos, Loot lootToSpawn)
        {
            Loot loot = Instantiate(lootToSpawn, randomTile.GetTileCenterPos(), Quaternion.identity);
            randomTile.SetLoot(loot);
        }

        private void SpawnEnemy(Tile randomTile, Vector2 tilePos,GameObject enemytToSpawn)
        {
            var enemy = Instantiate(enemytToSpawn, randomTile.GetTileCenterPos(), Quaternion.identity);
            randomTile.SetEntity(enemy);
        }

        private void GenerateMiniBossOrMimicWithFire(float probabilityOfMimic,float probabiltyOfTileIsOnFire)
        {


            GenerateMiniBoosOrMimic(probabilityOfMimic);
            // generate new TileMap
            for ( int i = 0; i< _tiles.Count; i++)
            {

                if (GetRandomValue() < probabiltyOfTileIsOnFire)
                {
                    UpdateTile(_tiles[i], fireTilePrefab);
                }
                
            }

        }

        private void UpdateTile(Tile tile, Tile newTile)
        {
            tile.UpdateSprite(newTile.GetSpriteRenderer().sprite);
            tile = newTile;
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

        public void Reset()
        {
            #if UNITY_EDITOR
            _tiles = GetComponentsInChildren<Tile>().ToList();
            #endif
            for (int i = 0; i < _tiles.Count; i++)
            {
                _tiles[i].UpdateSprite(groundTilePrefab.GetSpriteRenderer().sprite);
                _tiles[i] = groundTilePrefab.GetComponent<Tile>();
               
            }
        }
    }
}