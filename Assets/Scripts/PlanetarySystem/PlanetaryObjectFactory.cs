using System.Collections.Generic;

public class PlanetaryObjectFactory : IPlanetaryObjectFactory
{
    private List<IPlanetaryObject> _planetaryObjects = new List<IPlanetaryObject>();

    public IPlanetaryObject Create(double planetMass)
    {
        IPlanetaryObject planetaryObject = new PlanetaryObject(planetMass);

        _planetaryObjects.Add(planetaryObject);

        return planetaryObject;
    }
}