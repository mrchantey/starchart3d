using System;
using UnityEngine;

namespace Ahoy
{

    public class SineMover : MonoBehaviour
    {


        public float freq = 1;
        public float amp = 1;
        public bool doX;
        public bool doY;

        float theta;
        void Update()
        {
            theta += Time.deltaTime * freq;
            var x = doX ? Mathf.Cos(theta) * amp : 0f;
            var y = doY ? Mathf.Sin(theta) * amp : 0f;
            var pos = new Vector3(x, y, 0);
            transform.position = pos;
        }

    }
}