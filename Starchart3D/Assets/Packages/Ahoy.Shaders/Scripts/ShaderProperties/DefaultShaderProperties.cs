using UnityEngine;

namespace Ahoy.Shaders
{

	[CreateAssetMenu(fileName = "Default Shader Properties", menuName = "Ahoy.Shaders/Default Shader Properties", order = 0)]
	public class DefaultShaderProperties : ShaderPropertiesBase
	{
		public Color color = Color.white;
		public bool screenSpace;
		public int _screenSpace { get { return screenSpace ? 1 : 0; } }
		[Range(0, 10)]
		public float size = 1f;
		[Range(0, 1)]
		public float scaleRange = 0;
		[Range(0, 1000)]
		public float scaleMax = 1;
		[Range(1, 1000)]
		public float scaleDivisor = 1;


		public override void Apply(ComputeShader shader, int kernelIndex)
		{
			shader.SetVector("_Color", color);
			shader.SetInt("_ScreenSpace", _screenSpace);
			shader.SetFloat("_Size", size);
			shader.SetFloat("_ScaleDivisor", scaleDivisor);
			shader.SetFloat("_ScaleRange", scaleRange);
			shader.SetFloat("_ScaleMax", scaleMax);
		}

		public override void Apply(Material shader)
		{
			shader.SetColor("_Color", color);
			shader.SetInt("_ScreenSpace", _screenSpace);
			shader.SetFloat("_Size", size);
			shader.SetFloat("_ScaleDivisor", scaleDivisor);
			shader.SetFloat("_ScaleRange", scaleRange);
			shader.SetFloat("_ScaleMax", scaleMax);
		}
	}
}