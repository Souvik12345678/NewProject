using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.U2D;

public class TerrainScroller : MonoBehaviour
{

    public float chunkLen;

    //public Camera cam;
    public CinemachineVirtualCamera cam;
    public GameObject terrainPrefab;

    private Queue<GameObject> terrainChunksQ = new Queue<GameObject>(3);
    public GameObject lastChunk;
    private int currTerrIndx = -1;
    private float terrMaxX;

    public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        terrainChunksQ.Enqueue(lastChunk);
    }

    // Update is called once per frame
    void Update()
    {

        float camMaxX = cam.transform.position.x + cam.m_Lens.OrthographicSize * 2;

        Vector3 pos = lastChunk.transform.TransformPoint(lastChunk.GetComponent<TerrainGenerator>().rightMostPoint);

        test.transform.position = pos;

        //Debug.Log(test.transform.position);

        if (camMaxX > pos.x )
        {
            var gO = Instantiate(terrainPrefab, transform);

            gO.transform.position = new Vector2(pos.x, lastChunk.transform.position.y);

            //Generate random
            float s = Random.Range(1.0f, 10.0f);

            gO.GetComponent<TerrainGenerator>()._noiseStep = s;
            gO.GetComponent<TerrainGenerator>().GenerateTerrain(pos);

            lastChunk = gO;
            terrainChunksQ.Enqueue(gO);
        }


    }
}
