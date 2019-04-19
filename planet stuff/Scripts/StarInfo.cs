using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StarInfo
{

    // public int StarID;//0
    public int hipid;//1
    //public int hdid;//2
    // public int HR;//3
    // public int Gliese;//4
    // public int BayerFlamsteed;//5
    //public string properName;//6
    // public double RA;//7
    // public double Dec;//8
    public Color color = new Color(1, 1, 1, 1);
    public float distance;//9
                          // public double PMRA;//10
                          // public double PMDec;//11
                          // public double RV;//12
    public float magnitude;//13
    public float absoluteMagnitude;//14
                                   // public double Spectrum;//15
                                   // public double ColorIndex;//16
    public Vector3 position;//17 18 19 //X,Z,Y
    public Vector3 velocity;//20 21 22 //X,Z,Y


    public StarInfo(string text)
    {
        string[] fields = text.Split(',');
        hipid = int.Parse(fields[1]);
        //   properName = fields[6];
        magnitude = float.Parse(fields[13]);
        absoluteMagnitude = float.Parse(fields[14]);
        distance = float.Parse(fields[9]);
        position = new Vector3(
            float.Parse(fields[17]),
            float.Parse(fields[19]),
            float.Parse(fields[18]));//swap z and y
        velocity = new Vector3(
            float.Parse(fields[20]),
            float.Parse(fields[22]),
            float.Parse(fields[21]));//swap z and y
    }


}

/*
#####hygfull.csv:

1. StarID: The database primary key from a larger "master database" of stars.
2. HD: The star's ID in the Henry Draper catalog, if known.
3. HR: The star's ID in the Harvard Revised catalog, which is the same as its number in the Yale Bright Star Catalog.
4. Gliese: The star's ID in the third edition of the Gliese Catalog of Nearby Stars.
5. BayerFlamsteed: The Bayer / Flamsteed designation, from the Fifth Edition of the Yale Bright Star Catalog. This is a combination of the two designations. The Flamsteed number, if present, is given first; then a three-letter abbreviation for the Bayer Greek letter; the Bayer superscript number, if present; and finally, the three-letter constellation abbreviation. Thus Alpha Andromedae has the field value "21Alp And", and Kappa1 Sculptoris (no Flamsteed number) has "Kap1Scl".
6. RA, Dec: The star's right ascension and declination, for epoch 2000.0. Stars present only in the Gliese Catalog, which uses 1950.0 coordinates, have had these coordinates precessed to 2000.
 ProperName: A common name for the star, such as "Barnard's Star" or "Sirius". I have taken these names primarily from the Hipparcos project's web site, which lists representative names for the 150 brightest stars and many of the 150 closest stars. I have added a few names to this list. Most of the additions are designations from catalogs mostly now forgotten (e.g., Lalande, Groombridge, and Gould ["G."]) except for certain nearby stars which are still best known by these designations.
8. Distance: The star's distance in parsecs, the most common unit in astrometry. To convert parsecs to light years, multiply by 3.262. A value of 10000000 indicates missing or dubious (e.g., negative) parallax data in Hipparcos.
9. Mag: The star's apparent visual magnitude.
10. AbsMag: The star's absolute visual magnitude (its apparent magnitude from a distance of 10 parsecs).
11. Spectrum: The star's spectral type, if known.
12. ColorIndex: The star's color index (blue magnitude - visual magnitude), where known.
                                                       
#####hygxyz.csv: the fields in hygfull, plus some additional fields useful for mapping tools:

13. X,Y,Z: The Cartesian coordinates of the star, in a system based on the equatorial coordinates as seen from Earth. +X is in the direction of the vernal equinox (at epoch 2000), +Z towards the north celestial pole, and +Y in the direction of R.A. 6 hours, declination 0 degrees.
14. VX,VY,VZ: The Cartesian velocity components of the star, in the same coordinate system described immediately above. They are determined from the proper motion and the radial velocity (when known). The velocity unit is parsecs per year; these are small values (around 10-5 to 10-6), but they enormously simplify calculations using parsecs as base units for celestial mapping.


#####Per Catalog

1.StarID
2.HIP
3.HD
4.HR
5.Gliese
6.BayerFlamsteed
7.ProperName
8.RA
9.Dec
10.Distance
11.PMRA
12.PMDec
13.RV
14.Mag
15.AbsMag
16.Spectrum
17.ColorIndex
18.x
19.y
20.z
21.vx
22.vy
23.vz





*/


