using UnityEngine;

namespace Movement
{
    public interface IEntity
    {
        void Move(Vector2 newPos);
    }
}