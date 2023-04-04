using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObstacleSpawner : MonoBehaviour
{
    public ObstacleRangesSO obstacleRanges;

    public Transform player;

    private void Update()
    {
        foreach (var item in obstacleRanges.obstacleProfiles)
        {
            if (RangeCheck(item))//Is in range of current obstacle profile
            {
                for (int i = 0; i < item.obstaclePrefabs.Length; i++)//For each obstacle prefab
                {
                    int j = FindTotalRatio(item.obstacleRatios);
                    int spnCount = (int)(((float)item.obstacleRatios[i] / j) * item.spawnCount);
                    
                    //Spawn spwnCount ammount of obstacles
                    for (int k = 0; k < spnCount; k++)
                    {
                        Vector3 pos = new Vector3(Random.Range(item.startDist, item.endDist), 5);
                        //SpawnObject(item.obstaclePrefabs[i], pos);
                        SpawnObjectOnGround(item.obstaclePrefabs[i], pos.x);
                        
                    }
                }
                item.isUsed = true;
            }
        }

    }

    bool RangeCheck(ObstacleRangeProfileSO prof)
    {
        if (player.position.x > prof.startDist && player.position.x < prof.endDist)
        {
            return !prof.isUsed;
        }
        return false;
    }

    int FindTotalRatio(int[] arr)
    {
        int sum = 0;
        foreach (var item in arr)
            sum += item;
        return sum;
    }

    GameObject SpawnObject(GameObject prefab, Vector3 pos)
    {
        var gm = Instantiate(prefab, pos, Quaternion.identity);
        return gm;
    }

    GameObject SpawnObjectOnGround(GameObject prefab,float xPos)
    {
        RaycastHit2D hit;
        hit = Physics2D.Raycast(new Vector2(xPos, 10), Vector2.down, 100, LayerMask.GetMask("Terrain"));
        if (hit.collider == null) return null;//Nothing was hit
        Debug.DrawLine(new Vector2(xPos, 10), hit.point, Color.green, 1);
        var gm = Instantiate(prefab, hit.point + new Vector2(0,2f), Quaternion.identity);
        return gm;
    }

}
