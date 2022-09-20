using System.Linq;
using UnityEngine;

public class PlanetaryObject : MonoBehaviour, IPlanetaryObject
{
    [SerializeField] private double _mass;
    [SerializeField] private MassClassEnum _massClass;
    [SerializeField] private float _radius;

    public double Mass() => _mass;
    public MassClassEnum MassClass() => _massClass;
    public float Radius() => _radius;

    public PlanetaryObject(double mass)
    {
        _mass = mass;
        _massClass = GetMassClassByMass(_mass);
        _radius = GetRadiusByMass(_mass);
    }

    private float GetRadiusByMass(double mass)
    {
        MassClassConfig massClassConfig = DataManager.Instance.MassClassConfig.MassConfigs.Where(
            x => x.Mass.IsInRange(mass)).FirstOrDefault();
        
        double massRange = massClassConfig.Mass.Max - massClassConfig.Mass.Min;
        double massPercent = (mass - massClassConfig.Mass.Min) / massRange;
        double radiusRange = massClassConfig.Radius.Max - massClassConfig.Radius.Min;

        return (float)(radiusRange * massPercent + massClassConfig.Radius.Min);
    }

    private MassClassEnum GetMassClassByMass(double mass)
    {
        MassClassEnum massClass = DataManager.Instance.MassClassConfig.MassConfigs.Where(
            x => x.Mass.IsInRange(mass)).FirstOrDefault().MassClass;

        return massClass;
    }
}
