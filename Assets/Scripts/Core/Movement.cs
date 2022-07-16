using System.Threading.Tasks;
using UnityEngine;


namespace Core

{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private bool _isMoving;
        public bool IsMoving => _isMoving;

        private bool isMoving;

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

            
            isMoving = true;
            Vector2 currrentPos = gameObject.transform.position;
            while ((currrentPos - newPos).magnitude > 0.01f)
            {
                var dir = (newPos - currrentPos).normalized;
                var displacement =  speed * Time.deltaTime * dir;
                var moveAmount =  displacement + currrentPos;
                transform.position = moveAmount;
                currrentPos = transform.position;
                await Task.Yield();
            }
            transform.position = newPos;
            
        }


    }
}
