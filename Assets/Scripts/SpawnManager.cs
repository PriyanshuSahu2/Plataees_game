
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public
    GameObject[] spawnPoints;
    public static SpawnManager Instance;
    private void Awake()
    {
        Instance = this;

    }
    public Transform GetSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)].transform;
    }
}
