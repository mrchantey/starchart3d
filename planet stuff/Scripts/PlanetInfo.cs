using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[System.Serializable]
public class PlanetInfo
{
    public string name;//1
    public int id;//0
    public string type;//2
    public int orderFromSun;//3
    public float diameterEarth;//4
    public float diameterkm;//5
    public float massEarth;//6
    public float avgDistFromSunAU;//7
    public float orbitalPeriod;//8
    public float orbitalEccentricity;//9
    public float meanOrbitalVelocity;//10
    public float rotationPeriodDays;//11
    public float inclinationOfAxisDegrees;//12
    public float meanTemperatureDegrees;//13
    public float earthGravityAtEquator;//14
    public float escapeVelocityKmSec;//15
    public float meanDensityWater;//16
    public string atmosphericComposition;//17
    public int numberOfMoons;//18
    public bool rings;//19
    public int parent;//20
    public string image;//21
    public string url;//22
    public float J2000Longitude;//23

    public PlanetInfo(string text)
    {
        string[] fields = text.Split(',').Select(f => setEmptyNumbers(f)).ToArray();
        id = int.Parse(fields[0]);
        name = fields[1];
        type = fields[2];
        orderFromSun = int.Parse(fields[3]);
        diameterEarth = float.Parse(fields[4]);
        diameterkm = float.Parse(fields[5]);
        massEarth = float.Parse(fields[6]);
        avgDistFromSunAU = float.Parse(fields[7]);
        orbitalPeriod = float.Parse(fields[8]);
        orbitalEccentricity = float.Parse(fields[9]);
        meanOrbitalVelocity = float.Parse(fields[10]);
        rotationPeriodDays = float.Parse(fields[11]);
        inclinationOfAxisDegrees = float.Parse(fields[12]);
        meanTemperatureDegrees = float.Parse(fields[13]);
        earthGravityAtEquator = float.Parse(fields[14]);
        escapeVelocityKmSec = float.Parse(fields[15]);
        meanDensityWater = float.Parse(fields[16]);
        atmosphericComposition = fields[17];
        numberOfMoons = int.Parse(fields[18]);
        rings = bool.Parse(fields[19]);
        //parent = int.Parse(fields[20]);
        image = fields[21];
        url = fields[22];
        J2000Longitude = float.Parse(fields[23]);
    }

    string setEmptyNumbers(string a)
    {
        return (String.IsNullOrEmpty(a)) ? "0" : a;
    }
}
