using UnityEngine;
using UnityEngine.UI;

namespace Ahoy
{

	public class TransformToQuaternionVariable : TransformToVariable
	{

		public QuaternionVariable variable;

		public override void Invoke()
		{
			variable.value = value.rotation;
		}



	}
}