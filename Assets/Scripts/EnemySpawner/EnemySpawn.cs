using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DiceSystem;




public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private SpriteRenderer background;
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private Sprite[] backgroundSprites;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private GameObject bossPrefab;

    public D6_Dice dice = new D6_Dice();
    void Start()
    {
        SetBackground();
        SpawnEnemy();
    }

    // Update is called once per 
    private void OnEnable()
    {
        SetBackground();

    }
   
    void SetBackground()
    {
        int result = dice.RollResult();
        if(result <= 2)
        {
            background.sprite = backgroundSprites[0];
        }
        else if(result <= 4)
        {
            background.sprite = backgroundSprites[1];
        }
        else
        {
            background.sprite = backgroundSprites[2];
        }
    }
    void SpawnEnemy()
    {
        int result = dice.RollResult() - 1;
        

        if (result > 5)
        {
            Debug.Log(result);
            result -= 2;
        }
        Debug.Log(result);
        Instantiate(enemyPrefabs[result], enemySpawnPoint.position, Quaternion.identity, enemySpawnPoint);
    }

    void SpawnBoss() // Use to spawn boss when a condition is met
    {

        Instantiate(bossPrefab, enemySpawnPoint.position, Quaternion.identity, enemySpawnPoint);
    }

}
