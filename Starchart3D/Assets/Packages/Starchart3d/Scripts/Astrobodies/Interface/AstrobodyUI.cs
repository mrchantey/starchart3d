using UnityEngine;

namespace Starchart3D
{
	[RequireComponent(typeof(AstrobodyMono))]
	public class AstrobodyUI : MonoBehaviour
	{
		public bool debug = true;

		AstrobodyMono astrobodyMono;

		void Start()
		{
			astrobodyMono = GetComponent<AstrobodyMono>();
		}


		void Update()
		{
			if (!debug)
				return;

			var body = astrobodyMono.body;
			if (debug) Debug.Log($"AstrobodyUI - {body}");


		}


	}
}