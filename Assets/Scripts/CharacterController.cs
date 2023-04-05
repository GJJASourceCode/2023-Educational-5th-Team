using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private int rail = 0;
    private bool canMove = true;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hi");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftArrow) && rail > -1 && canMove)
        {
            rail -= 1;
            transform.position += new Vector3(-1.5f,0,0);
            StartCoroutine(MoveDelay());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && rail < 1 && canMove)
        {
            rail += 1;
            transform.position += new Vector3(1.5f,0,0);
            StartCoroutine(MoveDelay());

        }
    }

    IEnumerator MoveDelay()
    {
        canMove = false;
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }

}
