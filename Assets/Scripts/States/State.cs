namespace States
{
    public abstract class State
    {
        protected TurnSystem _turnSystem;

        public State(TurnSystem system)
        {
            _turnSystem = system;
        }

        public abstract void Start();
        public abstract void Attack();
        public abstract void Heal();
        public abstract void Move();
        public abstract void End();
        
    }
}