using UnityEngine;



public static class PoseExtensions
{

    public static Pose Lerp(this Pose a, Pose b, float t)
    {
        Vector3 position = Vector3.Lerp(a.position, b.position, t);
        Quaternion rotation = Quaternion.Slerp(a.rotation, b.rotation, t);
        return new Pose(position, rotation);
    }

    public static Pose Slerp(this Pose a, Pose b, float t)
    {
        Vector3 position = Vector3.Slerp(a.position, b.position, t);
        Quaternion rotation = Quaternion.Slerp(a.rotation, b.rotation, t);
        return new Pose(position, rotation);
    }

}