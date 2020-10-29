


using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Events;

namespace Ahoy
{

    [Serializable]
    public struct vec2
    {
        public float x;
        public float y;

        public vec2(Vector2 vec)
        {
            x = vec.x;
            y = vec.y;
        }
        public Vector2 ToVector2()
        {
            return new Vector2(x, y);
        }
        public override string ToString()
        {
            return $"({x.ToString("0.00")},{y.ToString("0.00")})";
        }


    }
    [Serializable]
    public struct vec3
    {
        public float x;
        public float y;
        public float z;

        public vec3(Vector3 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }
        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
        }
        public override string ToString()
        {
            return $"({x.ToString("0.00")},{y.ToString("0.00")},{z.ToString("0.00")})";
        }

    }
    [Serializable]
    public struct vec4
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public vec4(Vector4 vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
            w = vec.w;
        }
        public vec4(Quaternion vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
            w = vec.w;
        }

        public Vector4 ToVector4()
        {
            return new Vector4(x, y, z, w);
        }
        public Quaternion ToQuaternion()
        {
            return new Quaternion(x, y, z, w);
        }
        public override string ToString()
        {
            return $"({x.ToString("0.00")},{y.ToString("0.00")},{z.ToString("0.00")},{w.ToString("0.00")})";
        }

    }
    [Serializable]
    public struct vec3vec4
    {
        public vec3 position;
        public vec4 rotation;
        public vec3vec4(Pose _vec3vec4)
        {
            position = _vec3vec4.position.ToVec3();
            rotation = _vec3vec4.rotation.ToVec4();
        }
        public vec3vec4(Vector3 _position, Quaternion _rotation)
        {
            position = _position.ToVec3();
            rotation = _rotation.ToVec4();
        }
        public vec3vec4(vec3 _position, vec4 _rotation)
        {
            position = _position;
            rotation = _rotation;
        }

        public Pose ToPose()
        {
            return new Pose(position.ToVector3(), rotation.ToQuaternion());
        }
        public override string ToString()
        {
            return $"(position: {position.ToString()}, rotation: {rotation.ToString()})";
        }

    }

    public static class SerializableExtensions
    {
        public static Vector2[] ToVector2(this vec2[] vecs) { return vecs.Select(v => v.ToVector2()).ToArray(); }
        public static vec2[] ToVec2(this Vector2[] vecs) { return vecs.Select(v => new vec2(v)).ToArray(); }
        public static vec2 ToVec2(this Vector2 vec) { return new vec2(vec); }

        public static Vector3[] ToVector3(this vec3[] vecs) { return vecs.Select(v => v.ToVector3()).ToArray(); }
        public static vec3[] ToVec3(this Vector3[] vecs) { return vecs.Select(v => new vec3(v)).ToArray(); }
        public static vec3 ToVec3(this Vector3 vec) { return new vec3(vec); }

        public static Vector4[] ToVector4(this vec4[] vecs) { return vecs.Select(v => v.ToVector4()).ToArray(); }
        public static vec4[] ToVec4(this Vector4[] vecs) { return vecs.Select(v => new vec4(v)).ToArray(); }
        public static vec4 ToVec4(this Vector4 vec) { return new vec4(vec); }
        public static vec4 ToVec4(this Quaternion vec) { return new vec4(vec); }

        public static Quaternion[] ToQuaternion(this vec4[] vecs) { return vecs.Select(v => v.ToQuaternion()).ToArray(); }
        public static vec4[] ToVec4(this Quaternion[] vecs) { return vecs.Select(v => new vec4(v)).ToArray(); }

        public static Pose[] ToPose(this vec3vec4[] vec3vec4s) { return vec3vec4s.Select(v => v.ToPose()).ToArray(); }
        public static vec3vec4[] ToPose(this Pose[] vec3vec4s) { return vec3vec4s.Select(v => new vec3vec4(v)).ToArray(); }
        public static vec3vec4 ToPose(this Pose p) { return new vec3vec4(p); }
    }

}