using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{

    public float speed = 7.0f;

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;


        if (transform.position.z < -3.0f)
        {
            Destroy(gameObject);
        }
    }
}
