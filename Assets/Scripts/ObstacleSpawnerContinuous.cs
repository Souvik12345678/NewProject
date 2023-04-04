using UnityEngine;

public class ObstacleSpawnerContinuous : MonoBehaviour
{

    //Point in world where the spawning starts
    public float startPointX;
    public float endPointX;

    public CommonAssetSO commonAssets;

    public Transform player;
    public Transform rightLimit;
    
    [Range(0.001f,100)]
    public float spawnInterval;

    float counter;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;

        if (counter >= spawnInterval)
        {
            SpawnObstacleRoutine();
            counter = 0;
        }
        counter += Time.deltaTime;
    }

    void SpawnObstacleRoutine()
    {
        //If in the range of spawning 
        if (transform.position.x > startPointX && transform.position.x < endPointX && !CheckIfInDiscreteRange())
        {
            SpawnObstacleAtMyCurrentPos();
        }
    }

    void SpawnObstacleAtMyCurrentPos()
    {
        int i = Random.Range(0, commonAssets.AllObstacles.Length);
        GameObject gm = CreateObstacle(i);
        gm.transform.position = transform.position;
    }

    GameObject CreateObstacle(int i)    
    {
        GameObject gm = commonAssets.AllObstacles[i];
        return Instantiate(gm);
    }

    //Checks if this objects current position is in some obstacle profile's ranges
    bool CheckIfInDiscreteRange()
    {
        float x = transform.position.x;
        foreach (var item in commonAssets.AllObstacleRanges.obstacleProfiles)
        {
            if (x > item.startDist && x < item.endDist)
            {
                return true;
            }
        }
        return false;
    }

}
