using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DiceSystem;


public class DiceRoll : MonoBehaviour
{
    // Start is called before the first frame update
    public D6_Dice dice = new D6_Dice();

    public int rolledOutcome;

    [SerializeField] private Image diceImage;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private float count = 1f;
    [SerializeField] private bool isRolling;
    void Start()
    {
        isRolling = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartRollDice()
    {
        Debug.Log("Button clicked");
        if (isRolling) return;
        isRolling = true;
        StartCoroutine(RollDice());
    }
    public IEnumerator RollDice()
    {
        Debug.Log("Coroutine started");
        float time = 0;
        while (time <= count)
        {
            time += Time.deltaTime + 0.1f;
            Debug.Log(time);
            int randomImage = Random.Range(0, sprites.Length);
            yield return new WaitForSeconds(0.1f);
            diceImage.sprite = sprites[randomImage];
        }
        int rolledValue = dice.RollResult() ;
        rolledOutcome = rolledValue;
        diceImage.sprite = sprites[rolledValue - 1];
        isRolling = false;
        Debug.Log($"You're result is {rolledValue}");
        yield return null;
    }
}
