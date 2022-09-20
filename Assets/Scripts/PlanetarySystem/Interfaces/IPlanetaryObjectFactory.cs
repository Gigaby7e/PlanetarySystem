using System.Collections.Generic;

public interface IPlanetaryObjectFactory
{
    public IPlanetaryObject Create(double planetMass);
}