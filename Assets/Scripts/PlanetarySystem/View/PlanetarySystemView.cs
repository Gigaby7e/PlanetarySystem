using System.Collections.Generic;
using UnityEngine;

public class PlanetarySystemView : MonoBehaviour, IPlanetarySystemView
{
    [SerializeField] private PlanetaryObjectView _planetaryObjectView;

    public List<IPlanetaryObjectView> PlanetaryObjectViews() => _planetaryObjectViews;

    private double _systemRadius = 12d; //magic number, minimum system range
    private double _prevPlanetaryObjectRadius = 0d;
    private List<IPlanetaryObjectView> _planetaryObjectViews;

    public void Setup(IPlanetarySystem planetarySystem)
    {
        _planetaryObjectViews = new List<IPlanetaryObjectView>();

        foreach (IPlanetaryObject planetaryObject in planetarySystem.PlanetaryObjects())
        {
            IPlanetaryObjectView planetaryObjectView = Instantiate(_planetaryObjectView, this.transform);
            _planetaryObjectViews.Add(planetaryObjectView);
            _systemRadius += _prevPlanetaryObjectRadius + planetaryObject.Radius();
            _prevPlanetaryObjectRadius = planetaryObject.Radius();
            
            planetaryObjectView.Setup(planetaryObject, _systemRadius);
        }
    }
} 