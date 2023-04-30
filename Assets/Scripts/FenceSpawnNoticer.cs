using UnityEngine;

public class FenceSpawnNoticer : MonoBehaviour
{

    private void FixedUpdate()
    {

        if (transform.position.z <= 11.05f && transform.position.x == -2.9f)
        {
            FenceManager.canSpawn = true;
            Destroy(this);
        }
    }


}
