using UnityEngine;

namespace Core
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