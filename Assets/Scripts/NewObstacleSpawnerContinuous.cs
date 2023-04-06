using UnityEngine;

public class NewObstacleSpawnerContinuous : MonoBehaviour
{

    //Point in world where the spawning starts
    public float startPointX;
    public float endPointX;

    public CommonAssetSO commonAssets;

    public Transform player;

    //It also samples player position
    //Point where spawning occurs
    public Transform rightLimit;
    
    [Range(0.001f,100)]
    public float spawnInterval;

    float counter;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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
        if (rightLimit.position.x > startPointX && rightLimit.position.x < endPointX && !CheckIfInDiscreteRange())
        {
            //SpawnObstacleAtMyCurrentPos();

            float minX = rightLimit.position.x;
            float maxX = minX + 10;

            int c = CountObstaclesInArea(new Vector2(minX, -5), new Vector2(maxX, 5));

            int countToSpawn = Random.Range(0, 5);//Generate random spawn count

            countToSpawn -= c;//If some exists do not spawn extras

            //Spawn
            SpawnObstaclesAtRange(minX, maxX, countToSpawn);
        }
    }

    //Given minrange, maxrange and counttospawn spawn some obs
    void SpawnObstaclesAtRange(float minX, float maxX, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int j = Random.Range(0, commonAssets.AllObstacles.Length);
            GameObject gm = CreateObstacle(j);
            gm.transform.position = rightLimit.position + new Vector3(Random.Range(0, 10.0f), 5);
        }
    }

    GameObject CreateObstacle(int i)    
    {
        GameObject gm = commonAssets.AllObstacles[i];
        return Instantiate(gm);
    }


    //Utilities

    //Given a startPt and endPt it calculates no. of obstacles in that BB.
    int CountObstaclesInArea(Vector2 startPt, Vector2 endPt)
    {
        Collider2D[] coll;
        Vector2 s = endPt - startPt;
        coll = Physics2D.OverlapAreaAll(startPt, endPt, LayerMask.GetMask("Obstacles"));
        DrawBB(startPt, endPt);
        return coll.Length;
    }

    //Checks if this objects current position is in some obstacle profile's ranges
    bool CheckIfInDiscreteRange()
    {
        float x = rightLimit.position.x;
        foreach (var item in commonAssets.AllObstacleRanges.obstacleProfiles)
        {
            if (x > item.startDist && x < item.endDist)
            {
                return true;
            }
        }
        return false;
    }

    //Draw BoundingBox
    void DrawBB(Vector2 startPt, Vector2 endPt)
    {
        Vector2 a = new Vector2();
        Vector2 b = new Vector2();

        a = startPt;
        b.Set(endPt.x, startPt.y);
        Debug.DrawLine(a, b, Color.green, 2);

        a = b;
        b = endPt;
        Debug.DrawLine(a, b, Color.green, 2);

        a = endPt;
        b.Set(startPt.x, endPt.y);
        Debug.DrawLine(a, b, Color.green, 2);

        a = b;
        b = startPt;
        Debug.DrawLine(a, b, Color.green, 2);

    }
}
