using UnityEngine;




[CreateAssetMenu(menuName = "StarChart/Databases/Star")]
public class StarDatabaseLoader : DatabaseLoader
{

    public string databasePath;


    public override void LoadDatabase()
    {
        string[] lines = IOUtility.OpenLines(databasePath);
        foreach (var line in lines)
        {
            Debug.Log(line);
        }
    }



}