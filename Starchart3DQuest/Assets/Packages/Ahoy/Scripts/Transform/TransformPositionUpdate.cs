using System;
using System.Linq;
using UnityEngine;

namespace Ahoy
{

    public class TransformPositionUpdate : InvocableMono
    {


        public TimedVector3UnityEvent[] onDerivative;

        Vector3[] lastDerivative;
        Vector3[] derivative;

        float lastTime;
        Vector3 lastPos;

        void OnEnable()
        {
            derivative = new Vector3[onDerivative.Length];
            lastDerivative = new Vector3[onDerivative.Length];
        }

        public override void Invoke()
        {
            if (onDerivative.Length == 0)
                return;
            var dTime = Time.time - lastTime;
            if (dTime == 0) return;

            derivative[0] = (transform.position - lastPos) / dTime;

            lastTime = Time.time;
            lastPos = transform.position;
            onDerivative[0].Invoke(new TimedVector3() { value = derivative[0], time = Time.time });

            for (int i = 1; i < onDerivative.Length; i++)
            {
                var dPos = derivative[i - 1] - lastDerivative[i - 1];
                derivative[i] = dPos / dTime;
                // Debug.Log($"dpos: {dPos}\tdtime: {dTime}\tderivative: {derivative[i]}");
                onDerivative[i].Invoke(new TimedVector3() { value = derivative[i], time = Time.time });
            }
            derivative.CopyTo(lastDerivative, 0);
            if (invokeSettings.debug)
                Debug.Log($"derivatives: {derivative.Select(v => v.magnitude).ElementsToStringFormattable("\t", "0.00")}");
        }
    }
}