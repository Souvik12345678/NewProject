using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ObstacleRangeProfile", order = 1)]
public class ObstacleRangeProfileSO : ScriptableObject
{
    public bool isUsed = false;

    public float startDist;
    public float endDist;

    //Interval between spawning in secs.
    public float spawnInterval;
    
    //Distance between each obs
    public float spawnDistance;
    //Total ammount to spawn
    public int spawnCount;

    //Ratios between obstacle types to spawn corresponding index to obstacle prefabs
    public int[] obstacleRatios;
    public GameObject[] obstaclePrefabs;

}
