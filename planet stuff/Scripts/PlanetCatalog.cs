using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu]
public class PlanetCatalog : CatalogLoader
{

    public PlanetInfo[] planets;

    protected override void LoadCatalog(string[] lines)
    {
        planets = lines.Skip(1)
        .Select(l => new PlanetInfo(l))
        .ToArray();
    }

}
