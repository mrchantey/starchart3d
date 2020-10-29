using UnityEngine;
using UnityEngine.Events;
using System;

namespace Ahoy
{

	[Serializable]
	public class ComputeShaderUnityEvent : UnityEvent<ComputeShader, int> { }

}