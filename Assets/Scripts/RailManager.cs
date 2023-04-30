using UnityEngine;

public class RailManager : MonoBehaviour
{

    public static bool canSpawn = false;
    public GameObject rail;
    public Transform spawnPos;
    void Update()
    {
        if (canSpawn)
        {
            var railClone = Instantiate(rail, spawnPos.position, rail.transform.rotation);
            canSpawn = false;
            railClone.transform.SetParent(GameObject.Find("Rail").transform);

        }
    }


    public void StopSpawning()
    {
        canSpawn = false;
    }
}
