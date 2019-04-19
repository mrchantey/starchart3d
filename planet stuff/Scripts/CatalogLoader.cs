using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Linq;

public abstract class CatalogLoader : ScriptableObject
{

    public string path;
    public bool loadCatalog;

    void OnValidate()
    {
        if (loadCatalog)
        {
            loadCatalog = !loadCatalog;
            LoadCatalog(GetLines(path));
        }

    }

    protected abstract void LoadCatalog(string[] lines);

    protected string[] GetLines(string filePath)
    {
        filePath = filePath.Replace(@"\", @"/");
        return File.ReadAllLines(filePath)
            .Where(l => !String.IsNullOrEmpty(l))
            .ToArray();
    }

}
