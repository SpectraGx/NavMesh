using UnityEngine;

public class CityTargetsManager : MonoBehaviour
{
    public static CityTargetsManager Instance;

    [SerializeField] private Transform[] targets;

    void Awake()
    {
        Instance = this;
    }

    public Vector3 GetRandomTarget()
    {
        return targets[Random.Range(0, targets.Length)].position;
    }
}
