using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class CharacterController : MonoBehaviour
{
    public float moveTransitionSpeed = 5f;
    public float jumpForce = 300;

    private int rail = 1;
    private bool canJump = true;
    private Animator animator;
    private Rigidbody rb;

    private List<float> railPos = new List<float>()
    {
        -1.5f,
        0,
        1.5f
    };

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        Move();
    }


    private void OnCollisionEnter(Collision other)
    {
        canJump = true;
    }

    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(railPos[rail], transform.position.y, transform.position.z), Time.deltaTime * moveTransitionSpeed);
    }

    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && rail > 0)
        {
            rail -= 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && rail < 2)
        {
            rail += 1;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce);
            animator.SetTrigger("Jump");
            canJump = false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            rb.AddForce(Vector3.down * jumpForce);
            animator.SetTrigger("Slide");
        }
    }

}
