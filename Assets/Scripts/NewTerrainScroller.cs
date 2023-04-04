using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.U2D;

public class NewTerrainScroller : MonoBehaviour
{

    public float chunkLen;

    public GameObject terrainPrefab;

    private Queue<GameObject> terrainChunksQ = new Queue<GameObject>(3);
    public GameObject lastChunk;
    private int currTerrIndx = -1;
    private float terrMaxX;

    public GameObject test;

    //It is the max limit, if it reaches beyond last chunk a new terrain is generated.
    public Transform rightLimit;

    // Start is called before the first frame update
    void Start()
    {
        terrainChunksQ.Enqueue(lastChunk);
    }

    // Update is called once per frame
    void Update()
    {

        float maxX = rightLimit.position.x;

        Vector3 pos = lastChunk.transform.TransformPoint(lastChunk.GetComponent<TerrainGenerator>().rightMostPoint);

        //test.transform.position = pos;

        if (maxX > pos.x )
        {
            Vector3 p = new Vector2(pos.x, lastChunk.transform.position.y);
            
            var gO = Instantiate(terrainPrefab,p,Quaternion.identity);
            //gO.transform.position = new Vector2(pos.x, lastChunk.transform.position.y);

            //Generate random
            float s = Random.Range(1.0f, 10.0f);

            gO.GetComponent<TerrainGenerator>()._noiseStep = s;
            gO.GetComponent<TerrainGenerator>().GenerateTerrain(pos);

            lastChunk = gO;
            terrainChunksQ.Enqueue(gO);

        }


    }
}
