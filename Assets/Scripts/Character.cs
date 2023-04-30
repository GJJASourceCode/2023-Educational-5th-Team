using UnityEngine;

public class Character : MonoBehaviour
{
    public int health = 2;
    private Animator animator;

    private bool canFall = true;

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
            GameObject.FindObjectOfType<ObstacleManager>().StopSpawning();
            GameObject.FindObjectOfType<FenceManager>().StopSpawning();
            GameObject.FindObjectOfType<RailManager>().StopSpawning();
            Destroy(GetComponent<CharacterController>());

        }
    }
}
