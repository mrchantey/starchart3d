using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ConstellationInfo
{

    public string name;
    public bool isZodiac;
    public string shortName;
    //groups of 2
    public StarInfo[] stars;

    public ConstellationInfo(string text, StarCatalog starCatalog, Dictionary<string, string> names)
    {
        string[] fields = text.Split(' ').Where(t => t != " " && t != "").ToArray();
        shortName = fields[0];
        names.TryGetValue(shortName, out name);
        isZodiac = IsZodiac(name);
        int numLines = int.Parse(fields[1]);
        int[] lineIDs = new int[numLines * 2];
        stars = new StarInfo[lineIDs.Length];
        for (int i = 2; i < fields.Length; i += 2)
        {
            int ci = i - 2;
            lineIDs[ci] = int.Parse(fields[i]);
            lineIDs[ci + 1] = int.Parse(fields[i + 1]);

            stars[ci] = starCatalog.GetStarByHDID(lineIDs[ci]);
            stars[ci + 1] = starCatalog.GetStarByHDID(lineIDs[ci + 1]);
            stars[ci].color = Color.red;
            stars[ci + 1].color = Color.red;
        }
    }

    public override string ToString()
    {
        return "Constellation short name: " + shortName + "\tElement Count: " + stars.Length.ToString()
        + "\n" + stars.Select(s => s.position).ToArray().ElementsToString("\t");
    }

    bool IsZodiac(string constellationName)
    {
        switch (constellationName)
        {
            case "Aries":
            case "Aquarius":
            case "Cancer":
            case "Capricornus":
            case "Gemini":
            case "Leo":
            case "Libra":
            case "Pisces":
            case "Sagittarius":
            case "Scorpius":
            case "Taurus":
            case "Virgo":
                return true;
        }

        return false;
    }

}
