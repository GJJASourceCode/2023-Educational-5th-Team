using UnityEngine;

public class RailSpawnNoticer : MonoBehaviour
{

    private void FixedUpdate()
    {

        if (transform.position.z <= 15.5f)
        {
            RailManager.canSpawn = true;
            Destroy(this);
        }
    }


}
