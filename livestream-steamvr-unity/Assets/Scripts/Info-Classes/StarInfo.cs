using UnityEngine;
using System.Linq;



[System.Serializable]
public class StarInfo
{

    public int hygId;
    public int hipId;
    public float apparentMagnitude;//magnitude from earth
    public float absoluteMagnitude;//actual magnitude
    public string properName;
    public float colorIndex;
    public Color color;

    public Vector3 position;
    public Vector3 velocity;

    public StarInfo(string csvLine)
    {
        var lines = csvLine.Split(',');

        hygId = ParseUtility.SafeIntParse(lines[0]);
        hipId = ParseUtility.SafeIntParse(lines[1]);
        properName = lines[6];
        apparentMagnitude = ParseUtility.SafeFloatParse(lines[13]);
        absoluteMagnitude = ParseUtility.SafeFloatParse(lines[14]);

        colorIndex = ParseUtility.SafeFloatParse(lines[16]);
        color = ColorUtility.ColorIndexToRGB(colorIndex);

        position = new Vector3(
          ParseUtility.SafeFloatParse(lines[17]),
          ParseUtility.SafeFloatParse(lines[18]),
          ParseUtility.SafeFloatParse(lines[19])
        );
        velocity = new Vector3(
          ParseUtility.SafeFloatParse(lines[20]),
          ParseUtility.SafeFloatParse(lines[21]),
          ParseUtility.SafeFloatParse(lines[22])
        );
        position = Vector3.ClampMagnitude(position, 1000);
    }

}