using UnityEngine;

namespace Movement
{
    public abstract class Entity:MonoBehaviour
    {
        public abstract void Move(Vector2 newPos);
    }
}