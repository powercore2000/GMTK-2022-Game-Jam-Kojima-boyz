using System;
using UnityEngine;

namespace States
{
    public class BeginState : State
    {
        public BeginState(TurnSystem system) : base(system)
        {
            // do some stuff before battle starts                      
            //_turnSystem.SetState(new PlayerTurn(_turnSystem));
            Debug.Log("Contrsuctor");
        }

        public override void Start()
        {
            _turnSystem.SetState(new PlayerTurn(_turnSystem));
        }

        public override void Attack()
        {
            throw new NotImplementedException();
        }

        public override void Heal()
        {
            throw new NotImplementedException();
        }

        public override void Move()
        {
            throw new NotImplementedException();
        }

        public override void End()
        {
            throw new NotImplementedException();
        }
    }
}