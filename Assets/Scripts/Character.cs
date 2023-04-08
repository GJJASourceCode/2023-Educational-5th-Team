using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int health = 2;
    private Animator animator;

    private bool canFall = true;

    public ObstacleManager obstacleManager;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (health <= 0 && canFall)
        {
            animator.SetTrigger("Fall");
            canFall = false;
            obstacleManager.StopSpawning();
            Destroy(GetComponent<CharacterController>());

        }
    }
}
