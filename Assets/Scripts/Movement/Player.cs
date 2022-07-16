using System;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Player: MonoBehaviour
{
    private Movement _movement;
    
    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    public void Move(Vector2 newPos)
    {
        _movement.Move(newPos);
    }
}