using System;
using UnityEngine;
using Ahoy.Shaders;

namespace Ahoy.Compute
{

	public class ComputeInstance : MonoBehaviour
	{

		// public bool debug = true;
		[SerializeField]

		[HideInInspector]
		public ComputeShader computeShader;

		Vector3Int numGroups;


		public bool applyShaderPropertiesOnDispatch = true;
		public ShaderPropertiesBase shaderProperties;

		public int kernelIndex { get; private set; }

		public void Init(ComputeShader computeTemplate, int numThreads)
		{
			//ceil instead to generate all
			Init(computeTemplate, numThreads, 1, 1);
			// int width = Mathf.FloorToInt(Mathf.Pow(numThreads, 1 / 2f));
			// Init(width, width, 1);
			// Init(width, width, width);
			// Init(numThreads, 1, 1); 
		}

		public void Init(ComputeShader computeTemplate, Vector3Int numThreads)
		{
			Init(computeTemplate, numThreads.x, numThreads.y, numThreads.z);
		}

		public void Init(ComputeShader computeTemplate, int numThreadsX, int numThreadsY, int numThreadsZ)
		{
			computeShader = Instantiate(computeTemplate);

			kernelIndex = computeShader.FindKernel("CSMain");

			uint groupSizeX, groupSizeY, groupSizeZ;//these are 8,8,8
			computeShader.GetKernelThreadGroupSizes(kernelIndex, out groupSizeX, out groupSizeY, out groupSizeZ);

			numGroups.x = GetNumGroups(groupSizeX, numThreadsX);
			numGroups.y = GetNumGroups(groupSizeY, numThreadsY);
			numGroups.z = GetNumGroups(groupSizeZ, numThreadsZ);

			var numThreads = numThreadsX * numThreadsY * numThreadsZ;
			// if (debug) Debug.Log($"ComputeInstance - thread info:\ntotal:\t{numThreads}\nx:\t{numThreadsX}\ny:\t{numThreadsY}\nz:\t{numThreadsZ}\n");
			computeShader.SetInt("Ahoy_NumThreads", numThreads);
			computeShader.SetInt("Ahoy_NumThreadsX", numThreadsX);
			computeShader.SetInt("Ahoy_NumThreadsY", numThreadsY);
			computeShader.SetInt("Ahoy_NumThreadsZ", numThreadsZ);

			if (shaderProperties != null)
				shaderProperties.Apply(computeShader, kernelIndex);
		}

		//from that lady
		int GetNumGroups(uint groupSize, int numThreads)
		{
			//increase so that num groups includes all threads
			if (numThreads % groupSize > 0)
				numThreads += (int)groupSize - (numThreads % (int)groupSize);
			return numThreads / (int)groupSize;
		}

		public virtual void Dispatch()
		{
			if (shaderProperties != null & applyShaderPropertiesOnDispatch)
				shaderProperties.Apply(computeShader, kernelIndex);
			computeShader.Dispatch(kernelIndex, numGroups.x, numGroups.y, numGroups.z);
		}

		//this should only be done after initialization
		public void SetBool(String name, bool val) { computeShader.SetBool(name, val); }
		public void SetFloat(String name, float val) { computeShader.SetFloat(name, val); }
		public void SetInt(String name, int val) { computeShader.SetInt(name, val); }
		public void SetMatrix(String name, Matrix4x4 val) { computeShader.SetMatrix(name, val); }
		public void SetVector(String name, Vector4 val) { computeShader.SetVector(name, val); }
		public void SetBuffer(String name, ComputeBuffer val) { computeShader.SetBuffer(kernelIndex, name, val); }
		public void SetTexture(String name, Texture val) { computeShader.SetTexture(kernelIndex, name, val); }

	}
}