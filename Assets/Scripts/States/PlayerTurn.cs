﻿using System;
using System.Threading.Tasks;
using UnityEngine;

namespace States
{
    public class PlayerTurn : State
    {
        
        public PlayerTurn(TurnSystem system) : base(system)
        {
            
        }

        public override void Start()
        {
           
        }

        public override void Attack()
        {
            _turnSystem.HandleAttack(
                _turnSystem.PlayerStats, _turnSystem.EnemyStats, 
                delegate{ _turnSystem.SetState(new EnemyTurn(_turnSystem)); });
            
        }

        public override void Heal()
        {
            Debug.Log("Player heals");
            //Add a more relveant value later
            _turnSystem.PlayerStats.Heal(2);
        }

        public override void Move()
        {
            _turnSystem.Player.Move(_turnSystem.Player.ClickedTileCenterCoords);
            
            // check conditions of game
            
           
        }

        public override void Ability()
        {
            _turnSystem.PlayerStats.PlayerClass.Ability();

            // check conditions of game


        }

        public async void Wait()
        {
            await Waiting();
        }

        public async Task Waiting()
        {
            while (_turnSystem.Player.IsMoving)
            {
                await Task.Yield();
            }
        }
        public override void End()
        {
        }
    }
}