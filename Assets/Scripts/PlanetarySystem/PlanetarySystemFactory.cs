public class PlanetarySystemFactory : IPlanetarySystemFactory
{
    public IPlanetarySystem Create(double mass)
    {
        return new PlanetarySystem(mass);
    }
}
