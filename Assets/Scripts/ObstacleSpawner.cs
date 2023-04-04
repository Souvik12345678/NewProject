using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public CommonAssetSO commonAssets;

    public Transform player;

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
            SpawnObstacles();
            counter = 0;
        }

        counter += Time.deltaTime;

    }

    void SpawnObstacles()
    {
        //If has covered some distance
        if (transform.position.x > 150) //Spawn 2 types of obstacle else
        {
            int a = Random.Range(0, 2);

            var gm = CreateObstacle(a);
            gm.transform.position = transform.position;

        }
        else
        {
            var gm = Instantiate<GameObject>(obstaclePrefab);
            gm.transform.position = transform.position;
        }
    }

    GameObject CreateObstacle(int i)    
    {
        GameObject gm;

        if (i == 0)
        {
            gm = commonAssets.Tire;
        }
        else 
        {
            gm = commonAssets.WoodenCrate;
        }

        return Instantiate<GameObject>(gm);
    }

}
