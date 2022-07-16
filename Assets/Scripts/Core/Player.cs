using UnityEngine;
<<<<<<< HEAD

namespace Core
=======
using TurnSystem;
using MovementNamespace;


namespace MovementNamespace
>>>>>>> 1532fc5625585732e4f31dd16a24134e0e3501f7
{
    
    [RequireComponent(typeof(Movement))]
    public class Player: Entity
    {
        private Vector2 _desiredPos;
        public Vector2 ClickedTileCenterCoords => _desiredPos;
        public void SaveDesiredDestination(Vector2 clickedTileCenterPos)
        {
            _desiredPos = clickedTileCenterPos;
        }
        
        
    }
}