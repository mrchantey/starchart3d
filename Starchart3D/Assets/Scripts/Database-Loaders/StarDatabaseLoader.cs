using UnityEngine;
using System.Linq;
using Ahoy;
namespace Starchart3D
{

	[CreateAssetMenu(menuName = "StarChart/Databases/Star")]
	public class StarDatabaseLoader : DatabaseLoader
	{

		public string databasePath;
		[HideInInspector]
		public StarInfo[] stars;


		public override void LoadDatabase()
		{
			string[] lines = IOUtility.OpenLines(databasePath);
			stars = lines
			.Skip(1)
			.Select(l => new StarInfo(l))
			.ToArray();
		}


		public StarInfo GetStarByHipId(int hipId)
		{
			var starInfo = stars.FirstOrDefault(s => s.hipId == hipId);
			if (starInfo == null)
				Debug.LogWarning("Warning: no star with id " + hipId + " found");
			return starInfo;
		}


	}
}