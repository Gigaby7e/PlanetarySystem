using UnityEngine;

public class PlanetaryObjectView : MonoBehaviour, IPlanetaryObjectView
{
    [SerializeField] private Transform _sphere;
    
    private float _orbitRadius = 0f;

    public void Rotate(float speed)
    {
        transform.Rotate(new Vector3(0, speed / _orbitRadius, 0));
    }

    public void Setup(IPlanetaryObject planetaryObject, double orbitRadius)
    {
        _orbitRadius = (float)orbitRadius;

        _sphere.localScale = new Vector3(planetaryObject.Radius(), planetaryObject.Radius(), planetaryObject.Radius());
        _sphere.localPosition = new Vector3((float)orbitRadius,0,0);
    }
}
