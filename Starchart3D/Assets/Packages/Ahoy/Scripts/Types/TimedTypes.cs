using System;
using UnityEngine;
namespace Ahoy
{

    [Serializable]
    public abstract class TimedValue<T> : IEquatable<TimedValue<T>> where T : IEquatable<T>
    {

        public T value;
        public float time;

        // public TimedValue(T value, float time)
        // {
        //     this.value = value;
        //     this.time = time;
        // }


        public bool Equals(TimedValue<T> other)
        {
            return time == other.time && value.Equals(other.value);
        }

        public override string ToString()
        {
            return $"{time}:{value}";
        }
    }
    [Serializable]
    public class TimedFloat : TimedValue<float> { }
    [Serializable]
    public class TimedVector2 : TimedValue<Vector2> { }
    [Serializable]
    public class TimedVector3 : TimedValue<Vector3> { }
    [Serializable]
    public class TimedQuaternion : TimedValue<Quaternion> { }
    [Serializable]
    public class TimedPose : TimedValue<Pose> { }





}