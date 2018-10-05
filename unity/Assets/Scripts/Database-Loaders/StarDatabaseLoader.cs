using UnityEngine;
using System.Linq;



[CreateAssetMenu(menuName = "StarChart/Databases/Star")]
public class StarDatabaseLoader : DatabaseLoader
{

    public string databasePath;
    public StarInfo[] stars;


    public override void LoadDatabase()
    {
        string[] lines = IOUtility.OpenLines(databasePath);
        stars = lines
        .Skip(1)
        .Select(l => new StarInfo(l))
        .ToArray();
    }



}