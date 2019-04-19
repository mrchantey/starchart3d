using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[CreateAssetMenu]
public class StarCatalog : CatalogLoader
{

    [HideInInspector]
    public StarInfo[] stars;

    protected override void LoadCatalog(string[] lines)
    {
        stars = lines.Skip(1)
        .Select(l => new StarInfo(l))
        .OrderBy(s => s.distance)
        .ToArray();
    }

    public StarInfo GetStarByHDID(int id)
    {
        var star = stars.Where(s => s.hipid == id).First();
        if (star == null)
        {
            Debug.Log("Star not found with hdid: " + id);
            return null;
        }
        else
            return star;
    }
}
