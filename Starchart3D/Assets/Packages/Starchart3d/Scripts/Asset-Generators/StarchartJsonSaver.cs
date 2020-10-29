



using System;
using UnityEngine;
using Ahoy;

namespace Starchart3D
{

	[CreateAssetMenu(fileName = "StarchartJsonSaver", menuName = "Starchart3D/StarchartJsonSaver", order = 0)]
	public class StarchartJsonSaver : InvocableSO
	{

		public string saveDirectory = "Assets";
		public StarDatabaseLoader starDatabase;
		public ConstellationDatabaseLoader constellationDatabase;
		public bool repopulateDatabases;

		public override void Invoke()
		{
			if (repopulateDatabases)
			{
				starDatabase.LoadDatabase();
				constellationDatabase.LoadDatabase();
			}

			var starsJson = JsonArrayUtility.ArrayToJson<StarInfo>(starDatabase.stars);
			System.IO.File.WriteAllText($"{saveDirectory}/stars.json", starsJson);


			var constellationsJson = JsonArrayUtility.ArrayToJson<ConstellationInfo>(constellationDatabase.constellations);
			System.IO.File.WriteAllText($"{saveDirectory}/constellations.json", constellationsJson);

		}
	}
}