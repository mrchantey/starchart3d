using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace Ahoy
{

    public class LineGraph : MonoBehaviour
    {


        Mesh mesh;
        public MeshFilter meshFilter;

        public Text textXMin;
        public Text textYMin;
        public Text textXMax;
        public Text textYMax;
        public Text textAverage;


        void OnEnable()
        {
            mesh = new Mesh();
            mesh.name = "Line Graph";
            mesh.bounds = new Bounds(Vector3.zero, new Vector3(1f, 1f, 0.05f));
            meshFilter.mesh = mesh;
        }

        public void SetMesh(TimedFloatArrayPool data)
        {
            if (data.Length < 2)
                return;
            var xAxis = data.Select(tv => tv.time).ToArray();
            var yAxis = data.Select(tv => tv.value).ToArray();
            SetMesh(xAxis, yAxis);
        }


        public void SetMesh(TimedVector3ArrayPool data)
        {
            if (data.Length < 2)
                return;
            var xAxis = data.Select(tvec => tvec.time).ToArray();
            var yAxis = data.Select(tvec => tvec.value.magnitude).ToArray();
            SetMesh(xAxis, yAxis);
        }

        public void SetMesh(float[] arrX, float[] arrY)
        {
            var normalData = NormalizeData(arrX, arrY);
            var offset = new Vector3(-0.5f, -0.5f, 0f);
            mesh.vertices = normalData
            .Select(d => offset + new Vector3(d.x, d.y, 0))
            .OrderBy(d => d.x)
            .ToArray();
            var indices = GetLineIndicies(normalData.Length);
            mesh.SetIndices(indices, MeshTopology.Lines, 0);
        }

        public int[] GetLineIndicies(int vLen)
        {
            var iLen = (vLen - 1) * 2;
            var val = new int[iLen];
            for (int vi = 0, ii = 0; ii < iLen - 1; vi++, ii += 2)
            {
                val[ii] = vi;
                val[ii + 1] = vi + 1;
            }
            return val;
        }

        Vector2[] NormalizeData(float[] arrX, float[] arrY)
        {
            // Debug.Log($"d1-length: {d1.Length}");
            // Debug.Log($"d1-length: {d1.Length},data: {d1.ElementsToString()}");
            // var d2Normal = new Vector2[2] { Vector2.zero, Vector2.one };
            var d2 = new Vector2[arrX.Length];
            // var d2Y = d1.Select(tvec => tvec.value.sqrMagnitude).ToArray();
            var arrXNormal = NormalizeData(arrX);
            var arrYNormal = NormalizeData(arrY);

            textAverage.text = "Average: " + arrY.Average().ToString("0");
            textXMin.text = arrXNormal.min.ToString("0");
            textXMax.text = arrXNormal.max.ToString("0");
            textYMin.text = arrYNormal.min.ToString("0");
            textYMax.text = arrYNormal.max.ToString("0");

            var dataNormal = arrXNormal.data
            .Select((vec, index) => new Vector2(arrXNormal.data[index], arrYNormal.data[index]))
            .ToArray();
            return dataNormal;
        }


        (float[] data, float min, float max) NormalizeData(float[] d1)
        {
            float min = float.MaxValue;
            float max = float.MinValue;
            float[] d2 = new float[d1.Length];
            for (int i = 0; i < d1.Length; i++)
            {
                if (d1[i] < min) min = d1[i];
                if (d1[i] > max) max = d1[i];
            }
            if (min == max)
            {
                for (int i = 0; i < d1.Length; i++)
                {
                    d2[i] = 0;
                }
            }
            else
            {
                for (int i = 0; i < d1.Length; i++)
                {
                    d2[i] = Math.Map(d1[i], min, max, 0, 1);
                }
            }
            return (d2, min, max);
        }

    }
}