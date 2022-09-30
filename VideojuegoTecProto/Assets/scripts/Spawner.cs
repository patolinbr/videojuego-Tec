using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabObstaculo;
    
    public Vector3 positionSpawner = new Vector3(25, 1, 0);

    public float timeToSpawn;

    void Start()
    {
        InvokeRepeating("GenerateObj", 2, timeToSpawn);    
    }

    public void GenerateRandomObject()
    {
        float randomWait = Random.Range(0.1f, 0.9f);
        Invoke("GenerateObj", randomWait);
    }

    void GenerateObj()
    {

       
        //Instantiate(prefabObstaculo, positionSpawner, prefabObstaculo.transform.rotation);
        Instantiate(prefabObstaculo[Random.Range(0, prefabObstaculo.Length)], positionSpawner, Quaternion.identity);
    }
}
