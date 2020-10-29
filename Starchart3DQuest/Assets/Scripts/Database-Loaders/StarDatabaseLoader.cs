using UnityEngine;
using System.Linq;
using Ahoy;
namespace Starchart3D
{


	[CreateAssetMenu(menuName = "Starchart3D/Databases/Star")]
	public class StarDatabaseLoader : DatabaseLoader
	{

		public string databasePath;
		[HideInInspector]

		//should be a dictionary by hipId
		public StarInfo[] stars;

		public CoordinateConversionInfo coordinateConversionInfo = CoordinateConversionInfo.EquatorialToUnity;


		public override void LoadDatabase()
		{
			string[] lines = IOUtility.OpenLines(databasePath);
			stars = lines
			.Skip(1)
			.Select(l =>
			{
				var si = new StarInfo(l);
				si.position = coordinateConversionInfo.ParseVector3(si.position);
				si.velocity = coordinateConversionInfo.ParseVector3(si.velocity);
				return si;
			})
			.ToArray();
			// Debug.Log($"StarDatabaseLoader - {stars[100].color}");
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