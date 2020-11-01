using UnityEngine;
using System.Collections.Generic;
using System.Linq;


namespace Ahoy.Shaders
{

	public abstract class ShaderPropertiesBase : ScriptableObject
	{
		public abstract void Apply(ComputeShader shader, int kernelIndex);
		public abstract void Apply(Material shader);
	}



	[CreateAssetMenu(fileName = "Shader Properties", menuName = "Ahoy.Shaders/Shader Properties", order = 0)]
	public class ShaderProperties : ShaderPropertiesBase
	{

		public List<BoolShaderProperty> bools;
		public List<ColorShaderProperty> colors;
		public List<FloatShaderProperty> floats;
		public List<FloatArrayShaderProperty> floatArrays;
		public List<IntShaderProperty> ints;
		public List<MatrixShaderProperty> matrices;
		public List<MatrixArrayShaderProperty> matrixArrays;
		public List<TextureShaderProperty> textures;
		public List<VectorShaderProperty> vectors;
		public List<VectorArrayShaderProperty> vectorArrays;
		public List<BufferShaderProperty> buffers;


		public override void Apply(ComputeShader shader, int kernelIndex)
		{
			bools.ForEach(v => shader.SetBool(v.name, v.value));
			colors.ForEach(v => shader.SetVector(v.name, v.value));
			floats.ForEach(v => shader.SetFloat(v.name, v.value));
			floatArrays.ForEach(v => shader.SetFloats(v.name, v.value));
			ints.ForEach(v => shader.SetInt(v.name, v.value));
			matrices.ForEach(v => shader.SetMatrix(v.name, v.value));
			matrixArrays.ForEach(v => shader.SetMatrixArray(v.name, v.value));
			textures.ForEach(v => shader.SetTexture(kernelIndex, v.name, v.value));
			vectors.ForEach(v => shader.SetVector(v.name, v.value));
			vectorArrays.ForEach(v => shader.SetVectorArray(v.name, v.value));
			buffers.ForEach(v => shader.SetBuffer(kernelIndex, v.name, v.value));
		}
		public override void Apply(Material shader)
		{
			bools.ForEach(v => shader.SetInt(v.name, v.value ? 1 : 0));
			colors.ForEach(v => shader.SetVector(v.name, v.value));
			floats.ForEach(v => shader.SetFloat(v.name, v.value));
			floatArrays.ForEach(v => shader.SetFloatArray(v.name, v.value));
			ints.ForEach(v => shader.SetInt(v.name, v.value));
			matrices.ForEach(v => shader.SetMatrix(v.name, v.value));
			matrixArrays.ForEach(v => shader.SetMatrixArray(v.name, v.value));
			textures.ForEach(v => shader.SetTexture(v.name, v.value));
			vectors.ForEach(v => shader.SetVector(v.name, v.value));
			vectorArrays.ForEach(v => shader.SetVectorArray(v.name, v.value));
			buffers.ForEach(v => shader.SetBuffer(v.name, v.value));
		}
		// public void ApplyGlobally()
		// {
		// 	bools.ForEach(v => Shader.SetGlobalInt(v.name, v.value ? 1 : 0));
		// 	colors.ForEach(v => Shader.SetGlobalVector(v.name, v.value));
		// 	floats.ForEach(v => Shader.SetGlobalFloat(v.name, v.value));
		// 	floatArrays.ForEach(v => Shader.SetGlobalFloatArray(v.name, v.value));
		// 	ints.ForEach(v => Shader.SetGlobalInt(v.name, v.value));
		// 	matrices.ForEach(v => Shader.SetGlobalMatrix(v.name, v.value));
		// 	matrixArrays.ForEach(v => Shader.SetGlobalMatrixArray(v.name, v.value));
		// 	textures.ForEach(v => Shader.SetGlobalTexture(v.name, v.value));
		// 	vectors.ForEach(v => Shader.SetGlobalVector(v.name, v.value));
		// 	vectorArrays.ForEach(v => Shader.SetGlobalVectorArray(v.name, v.value));
		// 	buffers.ForEach(v => Shader.SetGlobalBuffer(v.name, v.value));
		// }



	}
}