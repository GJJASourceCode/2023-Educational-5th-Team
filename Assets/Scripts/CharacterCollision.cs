using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
{

    private bool canCollision = true;

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Obstacle") && canCollision)
        {
            GetComponent<Character>().health -= 1;
            Debug.Log(GetComponent<Character>().health);
            StartCoroutine(CollisionDelay());
        }
    }

    IEnumerator CollisionDelay()
    {
        canCollision = false;
        yield return new WaitForSeconds(0.5f);
        canCollision = true;
    }

}
