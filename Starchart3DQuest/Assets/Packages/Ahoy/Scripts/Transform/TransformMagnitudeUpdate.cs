using UnityEngine;
using System.Linq;

namespace Ahoy
{

    public class TransformMagnitudeUpdate : InvocableMono
    {


        public TimedFloatUnityEvent[] onDerivative;

        float[] lastDerivative;
        float[] derivative;

        float lastTime;
        Vector3 lastPos;

        void OnEnable()
        {
            derivative = new float[onDerivative.Length];
            lastDerivative = new float[onDerivative.Length];
        }

        public override void Invoke()
        {
            if (onDerivative.Length == 0)
                return;
            var dTime = Time.time - lastTime;
            if (dTime == 0) return;

            derivative[0] = (transform.position - lastPos).magnitude / dTime;
            lastTime = Time.time;
            lastPos = transform.position;
            onDerivative[0].Invoke(new TimedFloat() { value = derivative[0], time = Time.time });

            for (int i = 1; i < onDerivative.Length; i++)
            {
                var dPos = derivative[i - 1] - lastDerivative[i - 1];
                derivative[i] = dPos / dTime;
                // Debug.Log($"dpos: {dPos}\tdtime: {dTime}\tderivative: {derivative[i]}");
                onDerivative[i].Invoke(new TimedFloat() { value = derivative[i], time = Time.time });
            }
            derivative.CopyTo(lastDerivative, 0);
            if (invokeSettings.debug)
                Debug.Log($"time: {dTime}\tderivatives: {derivative.Select(v => v).ElementsToStringFormattable("\t", "0.00")}");
        }
    }
}