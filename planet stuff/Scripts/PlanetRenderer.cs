using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlanetRenderer : AstroRenderer
{


    [Range(0, 10)]
    public float distanceScalar = 3;
    [Range(0, 1)]
    public float distanceCompressor = 0.25f;
    [Range(0, 10)]
    public float diameterScalar = 0.3f;
    [Range(0, 10)]
    public float diameterCompressor = 0.5f;
    public PlanetCatalog planetCatalog;
    [Range(1500, 2500)]
    public float currentYear = 2000;
    [Range(0, 10)]
    public float yearsPerSecond = 1;

    protected override void Render()
    {
        CreatePlanets();

    }


    protected override void Update()
    {
        base.Update();
        Array.ForEach(transform.GetComponentsInChildren<Planet>(), p => UpdatePlanet(p));
        currentYear += yearsPerSecond * Time.deltaTime;
    }

    void UpdatePlanet(Planet planet)
    {
        planet.UpdateOrbit(currentYear, distanceCompressor, distanceScalar);
        planet.UpdateScale(diameterCompressor, diameterScalar);
    }

    void CreatePlanets()
    {
        foreach (var planetInfo in planetCatalog.planets)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.name = planetInfo.name;
            go.transform.parent = transform;
            var planet = go.AddComponent<Planet>();
            planet.info = planetInfo;
            UpdatePlanet(planet);
        }

    }

}
