using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceManager : MonoBehaviour
{

     public static bool canSpawn = false;
    public GameObject fence;
    public List<Transform> spawnPos;
    void Update()
    {
        if (canSpawn)
        {
            foreach (var pos in spawnPos)
            {   
                Instantiate(fence, pos.position, fence.transform.rotation);
                canSpawn = false;
            }
        }
    }


    public void StopSpawning()
    {
        canSpawn = false;
    }
}
