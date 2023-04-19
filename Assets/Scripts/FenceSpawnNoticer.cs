using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawnNoticer : MonoBehaviour
{

    private void FixedUpdate()
    {

        if (transform.position.z < 11.05f && transform.position.x == -2.9f)
        {
            Debug.Log("체크");
            FenceManager.canSpawn = true;
            Destroy(this);
        }
    }


}
