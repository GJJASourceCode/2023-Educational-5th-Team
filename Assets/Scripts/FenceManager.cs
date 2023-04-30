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
                var fenceClone = Instantiate(fence, pos.position, fence.transform.rotation);
                canSpawn = false;

                fenceClone.transform.SetParent(GameObject.Find("Environment").transform);
            }
        }
    }


    public void StopSpawning()
    {
        canSpawn = false;
    }
}
