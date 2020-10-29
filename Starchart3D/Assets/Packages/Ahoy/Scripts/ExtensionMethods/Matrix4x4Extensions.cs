using UnityEngine;
public static class Matrix4x4Extensions
{


	/*
    Elements of a matrix:
    Data is accessed as: row + (column*4)

                | right  |  up    | fwd    | pos    |
                | col0   | col1   | col2   | col3   |
                | ------ | ------ | ------ | ------ | 
        X - row0| scaleX |        |        | posX   |
        Y - row1|        | scaleY |        | posY   |
        Z - row2|        |        | scaleZ | posZ   |
        W - row3|        |        |        |        |

    numbers:
    m00 m01 m02 m03
    m10 m11 m12 m13
    m20 m21 m22 m23
    m30 m31 m32 m33
    */


	public static Vector3 GetPosition(this Matrix4x4 m)
	{
		return m.GetColumn(3);
	}

	public static Vector3 GetRight(this Matrix4x4 m)
	{
		return m.GetColumn(0).normalized;
	}
	public static Vector3 GetUp(this Matrix4x4 m)
	{
		return m.GetColumn(1).normalized;
	}
	public static Vector3 GetForward(this Matrix4x4 m)
	{
		return m.GetColumn(2).normalized;
	}

	public static Quaternion GetRotation(this Matrix4x4 m)
	{
		return Quaternion.LookRotation(m.GetColumn(2), m.GetColumn(1));
	}

	// Extract new local scale

	public static Vector3 GetLossyScale(this Matrix4x4 m)
	{
		return new Vector3(m.GetColumn(0).magnitude, m.GetColumn(1).magnitude, m.GetColumn(2).magnitude);
	}

}
