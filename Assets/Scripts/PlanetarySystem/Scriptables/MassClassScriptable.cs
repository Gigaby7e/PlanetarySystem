using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MassClassConfig", menuName = "ScriptableObjects/MassClassConfig")]
public class MassClassScriptable : ScriptableObject
{
    public List<MassClassConfig> MassConfigs;
}

[Serializable]
public class MassClassConfig
{
    public MassClassEnum MassClass;
    public DoubleRange Radius;
    public DoubleRange Mass;
}

[Serializable]
public struct DoubleRange
{
    public double Min;
    public double Max;

    public bool IsInRange(double value)
    {
        return value >= Min && value <= Max;
    }
}

[Serializable]
public enum MassClassEnum
{
    Asteroidan,
    Mercurian,
    Subterran,
    Terran,
    Superterran,
    Neptunian,
    Jovian
}