using System.Collections;
using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private bool isMoving;

        public void Move(Vector2 newPos)
        {
            if(isMoving) return;
            StartCoroutine(MoveRoutine(newPos));
        
        }

        // will apply some smoothing, for now just raw and simple movement
        private IEnumerator MoveRoutine(Vector2 newPos)
        {
            isMoving = true;
            Vector2 currrentPos = gameObject.transform.position;
            float time = 0;
            while ((currrentPos - newPos).magnitude > 0.01f)
            {
                var dir = (newPos - currrentPos).normalized;
                var displacement =  speed * Time.deltaTime * dir;
                var moveAmount =  displacement + currrentPos;
                transform.position = moveAmount;
                currrentPos = transform.position;
                yield return null;
            }
            isMoving = false;
        }
    }
}
