using UnityEngine;

namespace Starchart3D
{

	public class AstrobodyMono : MonoBehaviour
	{

		public Astrobody body;

		float distOffset = 10;
		float distScalar = 0.0f;

		void Update()
		{
			var pos = body.equatorialCartGeo.EquatorialCartToUnityVector3();

			float mag = pos.magnitude * distScalar + distOffset;
			pos = pos.normalized * mag;


			transform.localPosition = pos;
		}

	}
}