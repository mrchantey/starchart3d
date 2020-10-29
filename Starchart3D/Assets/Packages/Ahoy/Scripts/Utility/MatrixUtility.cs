using UnityEngine;

//https://answers.unity.com/questions/12713/how-do-i-reproduce-the-mvp-matrix.html
public static class MatrixUtility
{



	public static void CalculateViewMatrix(Camera camera, out Matrix4x4 V) { V = camera.worldToCameraMatrix; }
	public static void CalculateModelMatrix(Transform transform, out Matrix4x4 M) { M = transform.localToWorldMatrix; }
	public static void CalculateProjectionMatrix(Camera camera, out Matrix4x4 P)
	{
		P = camera.projectionMatrix;
		bool d3d = SystemInfo.graphicsDeviceVersion.IndexOf("Direct3D") > -1;
		if (d3d)
		{
			// Invert Y for rendering to a render texture
			for (int i = 0; i < 4; i++)
			{
				P[1, i] = -P[1, i];
			}
			// Scale and bias from OpenGL -> D3D depth range
			for (int i = 0; i < 4; i++)
			{
				P[2, i] = P[2, i] * 0.5f + P[3, i] * 0.5f;
			}
		}
	}

	public static void CalculateModelMatrices(
		Transform transform,
		Matrix4x4 V,
		Matrix4x4 VP,
		out Matrix4x4 M,
		out Matrix4x4 MV,
		out Matrix4x4 MVP
		)
	{
		CalculateModelMatrix(transform, out M);
		MV = V * M;
		MVP = VP * M;
	}


	public static void CalculateViewProjectionMatrices(
		Camera camera,
		out Matrix4x4 V,
		out Matrix4x4 P,
		out Matrix4x4 VP
	)
	{
		CalculateViewMatrix(camera, out V);
		CalculateProjectionMatrix(camera, out P);
		VP = P * V;
	}

	public static void CalculateModelViewProjectionMatrices(
		Transform transform,
		Camera camera,
		out Matrix4x4 M,
		out Matrix4x4 V,
		out Matrix4x4 P,
		out Matrix4x4 VP,
		out Matrix4x4 MVP
	)
	{
		CalculateModelMatrix(transform, out M);
		CalculateViewMatrix(camera, out V);
		CalculateProjectionMatrix(camera, out P);
		VP = P * V;
		MVP = P * V * M;
	}


}