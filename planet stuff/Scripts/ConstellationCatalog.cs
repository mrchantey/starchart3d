using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[CreateAssetMenu]
public class ConstellationCatalog : CatalogLoader
{



    public string nameLookupPath;
    public StarCatalog starCatalog;
    public ConstellationInfo[] constellations;


    Dictionary<string, string> GetNames()
    {
        var lines = GetLines(nameLookupPath);
        var names = new Dictionary<string, string>();
        lines.Where(l => !String.IsNullOrEmpty(l))
        .ToList().ForEach(l =>
        {
            var fields = l.Split('\t');
            names.Add(fields[0], fields[1].Replace("\"", ""));
        });
        return names;
    }

    protected override void LoadCatalog(string[] lines)
    {
        var names = GetNames();
        constellations =
        lines.Select(l => new ConstellationInfo(l, starCatalog, names))
        .ToArray();
    }

}
