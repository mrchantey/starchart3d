using UnityEngine;
using System.Linq;



[System.Serializable]
public class StarInfo
{

    public int hygId;
    public int hipId;
    public string properName;
    public Vector3 position;

    public StarInfo(string csvLine)
    {
        var lines = csvLine.Split(',');

        hygId = ParseUtility.SafeIntParse(lines[0]);
        hipId = ParseUtility.SafeIntParse(lines[1]);
        properName = lines[6];
        position = new Vector3(
          ParseUtility.SafeFloatParse(lines[17]),
          ParseUtility.SafeFloatParse(lines[18]),
          ParseUtility.SafeFloatParse(lines[19])
        );
    }

}