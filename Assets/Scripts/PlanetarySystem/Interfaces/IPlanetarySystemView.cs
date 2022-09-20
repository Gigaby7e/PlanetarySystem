using System.Collections.Generic;

public interface IPlanetarySystemView
{
    public List<IPlanetaryObjectView> PlanetaryObjectViews();
    public void Setup(IPlanetarySystem planetarySystem);
}
