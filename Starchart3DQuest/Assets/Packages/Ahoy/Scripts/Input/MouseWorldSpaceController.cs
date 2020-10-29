using UnityEngine;

namespace Ahoy
{

    public class MouseWorldSpaceController : MonoBehaviour
    {
        [Range(0, 64)]
        public float distance = 1;
        public bool lockX;
        public bool lockY;
        public bool lockZ;

        private void Update()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var pos = ray.origin + ray.direction * distance;
            if (lockX)
                pos.x = transform.position.x;
            if (lockY)
                pos.y = transform.position.y;
            if (lockZ)
                pos.z = transform.position.z;
            transform.position = pos;
            transform.rotation = Quaternion.LookRotation(ray.direction, Vector3.up);
        }


    }

}