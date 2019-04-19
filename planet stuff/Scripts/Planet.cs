using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public PlanetInfo info;
    public bool debug;

    public void UpdateScale(float diameterCompressor, float diameterScalar)
    {
        float compressedDiameter = Mathf.Pow(info.diameterEarth + 1, diameterCompressor);
        transform.localScale = Vector3.one * compressedDiameter * diameterScalar;


    }

    public void UpdateOrbit(float currentYear, float distanceCompressor, float distanceScalar)
    {
        if (info.orbitalPeriod == 0)
            return;

        float epochYear = currentYear - 2000;
        float deg = info.J2000Longitude + 360 / info.orbitalPeriod * epochYear;

        float compressedDistance = Mathf.Pow(info.avgDistFromSunAU + 1, distanceCompressor);
        float radius = compressedDistance * distanceScalar;
        Vector2 pos = Degrees2Cartesian(deg, radius);
        transform.localPosition = new Vector3(pos.x, 0, pos.y);

    }


    Vector2 Degrees2Cartesian(float deg, float radius)
    {
        float theta = Degrees2Radians(deg);
        return new Vector2(
            Mathf.Cos(theta),
            Mathf.Sin(theta))
            * radius;
    }

    float Degrees2Radians(float deg)
    {
        return deg / 360 * Mathf.PI * 2;
    }
}
