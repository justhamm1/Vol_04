using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public GameObject billboards;
    public Vector3 spawnValues;

    void Start()
    {
        SpawnWaves();
    }

    void SpawnWaves()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        if (spawnPosition.x <= -0.1f)
        {
            //Make the random yRot affect the left side.
            Vector3 billboards.transform.rotation.y = new Vector3(spawnValues.x, Random.Range(-20f, -50), spawnValues.z);
        }
        /*
        else
        {
            //Make the random yRot affect the right side.
            Vector3 spawnRotation = new Vector3(spawnValues.x, Random.Range(20f, 50), spawnValues.z);
        }
        */
        //Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(billboards, spawnPosition, spawnRotation);
    }
}
