using UnityEngine;
using Ahoy;
namespace Starchart3D
{

	public class AstrobodiesMono : MonoBehaviour
	{
		public FloatVariable day;


		public AstrobodiesSO bodiesSO;

		public GameObject prefab;
		public GameObject sunPrefab;
		public GameObject moonPrefab;

		GameObject GetPrefab(string name)
		{
			switch (name)
			{
				case "sun":
					return sunPrefab;
				case "moon":
					return moonPrefab;
				default:
					return prefab;
			}
		}

		void Awake()
		{

			bodiesSO.value = new Astrobodies();

			bodiesSO.value.allBodies.ForEach(b =>
			{
				var go = GameObject.Instantiate(GetPrefab(b.constants.name));
				go.transform.parent = transform;
				go.name = b.constants.name;
				go.GetComponent<AstrobodyMono>().body = b;
			});

		}

		void Update()
		{
			bodiesSO.value.UpdateBodies(day.value);
		}

	}
}