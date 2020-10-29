
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using Ahoy;
namespace Starchart3D
{

	[CreateAssetMenu(menuName = "Starchart3D/Databases/Constellation")]
	public class ConstellationDatabaseLoader : DatabaseLoader
	{

		public string folderPath;
		public StarDatabaseLoader starDatabase;
		public ConstellationInfo[] constellations;

		public override void LoadDatabase()
		{
			// names.ForEach(kvp => Debug.Log("id:" + kvp.Key + "\tname:" + kvp.Value));
			var constellationsPath = folderPath + "/constellationship.fab";
			constellations = IOUtility
			.OpenLines(constellationsPath)
			.Select(l => new ConstellationInfo(l, starDatabase))
			.ToArray();
			var names = GetNames();
			AssignConstellationNames(names);
		}

		Dictionary<string, string> GetNames()
		{
			string namesPath = folderPath + "/constellation_names.eng.fab";
			return IOUtility
			.OpenLines(namesPath)
			.Select(l =>
			{
				string key = Regex.Match(l, @"\w+").ToString();
				string valueDirty = Regex.Match(l, "_[(]\".*?\"[)]").ToString();
				string value = Regex.Replace(valueDirty, "[_\"()]", string.Empty);
				return new KeyValuePair<string, string>(key, value);
			})
			.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
		}

		void AssignConstellationNames(Dictionary<string, string> names)
		{
			constellations.ForEach(c =>
			{
				string name;
				names.TryGetValue(c.id, out name);
				c.name = name == null ? "unknown" : name;
			}
			);


		}

	}
}