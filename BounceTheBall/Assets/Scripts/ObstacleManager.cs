using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obsPrefabs;
    public float ySpawn = 0;
    public float obsLength = 10;
    public int numberOfObs = 20;
    private List<GameObject> activeObs = new List<GameObject>();
    

    public Transform playerTransform;

    void Start()
    {
        

         for (int i = 0; i < numberOfObs; i++)
        {
            

            if (i == 0)
                SpawnObstacle(0);
            else if (i < 10)
                SpawnObstacle(Random.Range(1, 9));
            else if (i >= 10 && i < 18)
                SpawnObstacle(Random.Range(1, 15));
            else 
                SpawnObstacle(Random.Range(1, obsPrefabs.Length));

        }


    }

    // Update is called once per frame
    void Update()
    {
        

        if (playerTransform.position.y - 18 > ySpawn - (numberOfObs * obsLength))
        {
            SpawnObstacle(Random.Range(1, obsPrefabs.Length));
            DeleteObs();
        }





    }
    public void SpawnObstacle(int obsIndex)
    {
        GameObject go = Instantiate(obsPrefabs[obsIndex], transform.up * ySpawn , transform.rotation);
        activeObs.Add(go);
        ySpawn += obsLength;

    }

    private void DeleteObs()
    {
        Destroy(activeObs[0]);
        activeObs.RemoveAt(0);


    }



}
