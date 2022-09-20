using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private MassClassScriptable _massClassConfig;

    public MassClassScriptable MassClassConfig => _massClassConfig;
    public static DataManager Instance => _instance;

    private static DataManager _instance;

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}