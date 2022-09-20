using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] [Range (1, 100)] private float _speed = 1;
    [SerializeField] private int _rowCount = 1;
    [SerializeField] private int _systemsCount = 5;
    [SerializeField] private PlanetarySystemView _systemView;

    private delegate void Rotate(float speed);
    private Rotate _rotate;
    private IPlanetarySystemFactory _systemFactory;

    private List<IPlanetarySystemView> _planetarySystemViews = new List<IPlanetarySystemView>();
    private List<IPlanetarySystem> _planetarySystems = new List<IPlanetarySystem>();

    private void Start()
    {
        CreatePlanetarySystems();
        SpawnPlanetarySystemViews();
    }

    private void CreatePlanetarySystems()
    {
        _systemFactory = new PlanetarySystemFactory();

        for (int i = 0; i < _systemsCount; i++)
        {
            _planetarySystems.Add(_systemFactory.Create(Random.Range(0f, 5000f)));
        }
    }

    private void SpawnPlanetarySystemViews()
    {
        float xPos = 0;
        float zPos = 0;
        int iterator = 0;

        foreach (IPlanetarySystem system in _planetarySystems)
        {
            IPlanetarySystemView view = Instantiate(_systemView, new Vector3(xPos, 0f, zPos), Quaternion.identity);
            view.Setup(system);

            foreach (IPlanetaryObjectView planetaryObjectView in view.PlanetaryObjectViews())
            {
                _rotate += planetaryObjectView.Rotate;
            }

            zPos += 200;
            iterator++;

            if (iterator >= _rowCount)
            {
                xPos += 200;
                zPos = 0;
                iterator = 0;
            }


            _planetarySystemViews.Add(view);
        }
    }

    private void Update()
    {
        _rotate?.Invoke(_speed);
    }
}
