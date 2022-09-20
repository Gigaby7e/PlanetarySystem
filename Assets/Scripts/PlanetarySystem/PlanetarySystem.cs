using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystem : IPlanetarySystem
{
    private IPlanetaryObjectFactory _planetaryObjectFactory;
    private List<IPlanetaryObject> _planetaryObjects;
    private int _planetaryObjectCount;
    
    public PlanetarySystem(double totoaSystemMass)
    {
        Init();
        GenetareSystem(totoaSystemMass);
    }

    public void Init()
    {
        _planetaryObjectFactory = new PlanetaryObjectFactory();
        _planetaryObjects = new List<IPlanetaryObject>();
        _planetaryObjectCount = Random.Range(2, 8);
    }

    private void GenetareSystem(double totalSystemMass)
    {
        foreach (double mass in GetSplitedMass(totalSystemMass))
        {
            _planetaryObjects.Add(_planetaryObjectFactory.Create(mass));
        }
    }

    private List<double> GetSplitedMass(double totalSystemMass)
    {
        System.Random random = new System.Random();
        List<double> planetsMass = new List<double>();
        double tMass = totalSystemMass;

        for (int i = 0; i <= _planetaryObjectCount; i++)
        {
            double mass = 0;

            if (i != _planetaryObjectCount)
            {
                double rand = random.NextDouble();
                mass = rand * tMass;
            }
            else
                mass = tMass;

            tMass -= mass;

            planetsMass.Add(mass);
        }

        planetsMass.Shuffle();

        double debMass = 0;
        foreach (var item in planetsMass)
        {
            debMass += item;
        }

        return planetsMass;
    }

    public IEnumerable<IPlanetaryObject> PlanetaryObjects()
    {
        return _planetaryObjects;
    }
}