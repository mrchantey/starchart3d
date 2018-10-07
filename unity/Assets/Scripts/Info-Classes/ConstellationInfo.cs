

using System.Linq;
using System.Text.RegularExpressions;


[System.Serializable]
public class ConstellationInfo
{

    public StarInfo[] stars;
    public string id;
    public string name;


    public ConstellationInfo(string whiteSpaceText, StarDatabaseLoader starDatabase)
    {

        //008 3 88635 89931 89931 90185 90185 89642
        var lines = Regex.Split(whiteSpaceText.Trim(), @"\s+")
        .ToArray();
        id = lines[0];


        stars = lines
            .Skip(2)
            .Select(idStr => int.Parse(idStr))
            .Select(idInt => starDatabase.GetStarByHipId(idInt))
            .ToArray();
        // .ToArray();
    }


    public override string ToString()
    {
        return string.Format("id: {0}\tname: {1}\tnumber of lines:{2}", id, name, stars.Length / 2);
    }

}