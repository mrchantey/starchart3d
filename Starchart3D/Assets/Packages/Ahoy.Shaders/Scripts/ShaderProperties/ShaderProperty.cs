using UnityEngine;
using System;
namespace Ahoy.Shaders
{

	public class ShaderProperty<T>
	{
		public string name;
		public T value;
	}

	[Serializable]
	public class BoolShaderProperty : ShaderProperty<bool> { }
	[Serializable]
	public class ColorShaderProperty : ShaderProperty<Color> { }
	[Serializable]
	public class FloatShaderProperty : ShaderProperty<float> { }
	[Serializable]
	public class FloatArrayShaderProperty : ShaderProperty<float[]> { }
	[Serializable]
	public class IntShaderProperty : ShaderProperty<int> { }
	[Serializable]
	public class MatrixShaderProperty : ShaderProperty<Matrix4x4> { }
	[Serializable]
	public class MatrixArrayShaderProperty : ShaderProperty<Matrix4x4[]> { }
	[Serializable]
	public class TextureShaderProperty : ShaderProperty<Texture> { }
	[Serializable]
	public class VectorShaderProperty : ShaderProperty<Vector4> { }
	[Serializable]
	public class VectorArrayShaderProperty : ShaderProperty<Vector4[]> { }
	[Serializable]
	public class BufferShaderProperty : ShaderProperty<ComputeBuffer> { }



}