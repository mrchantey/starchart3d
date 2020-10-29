using UnityEngine;
using Ahoy;


public static class TransformExtensions
{
    public static void SetPositionAndRotation(this Transform tran, Pose pose, TransformSpace space = TransformSpace.World)
    {
        switch (space)
        {
            case TransformSpace.World:
                tran.position = pose.position;
                tran.rotation = pose.rotation;
                break;
            case TransformSpace.Local:
                tran.localPosition = pose.position;
                tran.localRotation = pose.rotation;
                break;
            case TransformSpace.Self:
                pose = pose.GetTransformedBy(tran);
                tran.position = pose.position;
                tran.rotation = pose.rotation;
                break;
        }
    }

    public static void SetPositionAndRotation(this Transform tran, Matrix4x4 matrix, TransformSpace space = TransformSpace.World)
    {
        SetPositionAndRotation(tran, new Pose(matrix.GetPosition(), matrix.GetRotation()), space);
    }

    public static Pose Pose(this Transform tran) { return new Pose() { position = tran.position, rotation = tran.rotation }; }
    public static Pose LocalPose(this Transform tran) { return new Pose() { position = tran.localPosition, rotation = tran.localRotation }; }
}