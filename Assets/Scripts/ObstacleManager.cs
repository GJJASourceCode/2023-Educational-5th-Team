using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public List<GameObject> obstacleList;
    public List<Transform> spawnPos;
    public float spawnDelayInSecond = 1f;

    private float delay = 0;

    void Update()
    {
        delay += Time.deltaTime;
        if (delay > spawnDelayInSecond)
        {
            int random = Random.Range(0, spawnPos.Count);
            Vector3 pos = spawnPos[random].position;


            random = Random.Range(0, obstacleList.Count);
            Instantiate(obstacleList[random], pos, Quaternion.Euler(0, 90, 0));

            delay = 0;
        }


    }
}
