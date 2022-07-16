using System.Threading.Tasks;
using UnityEngine;

<<<<<<< HEAD:Assets/Scripts/Core/Movement.cs
namespace Core
=======

namespace MovementNamespace
>>>>>>> 1532fc5625585732e4f31dd16a24134e0e3501f7:Assets/Scripts/Movement/Movement.cs
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
<<<<<<< HEAD:Assets/Scripts/Core/Movement.cs
        private bool _isMoving;
        public bool IsMoving => _isMoving;
=======

        private bool isMoving;
        private Entity player;
>>>>>>> 1532fc5625585732e4f31dd16a24134e0e3501f7:Assets/Scripts/Movement/Movement.cs
        void Start()
        {
        }

        public async Task Move(Vector2 newPos)
        {
            await MoveRoutine(newPos);
        }

        // will apply some smoothing, for now just raw and simple movement
        private async Task MoveRoutine(Vector2 newPos)
        {
<<<<<<< HEAD:Assets/Scripts/Core/Movement.cs
=======
            //turnSystem.StartEnemyCoroutine();
            Debug.Log("Should start enemy");
            isMoving = true;
>>>>>>> 1532fc5625585732e4f31dd16a24134e0e3501f7:Assets/Scripts/Movement/Movement.cs
            Vector2 currrentPos = gameObject.transform.position;
            float time = 0;
            while ((currrentPos - newPos).magnitude > 0.01f)
            {
                var dir = (newPos - currrentPos).normalized;
                var displacement =  speed * Time.deltaTime * dir;
                var moveAmount =  displacement + currrentPos;
                transform.position = moveAmount;
                currrentPos = transform.position;
                await Task.Yield();
            }

<<<<<<< HEAD:Assets/Scripts/Core/Movement.cs
            transform.position = newPos;

=======
            //turnSystem.HasMoved();
>>>>>>> 1532fc5625585732e4f31dd16a24134e0e3501f7:Assets/Scripts/Movement/Movement.cs
        }


    }
}
