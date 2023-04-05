using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class UnityAnimationEvent : UnityEvent<string>{};

public class CharacterController : MonoBehaviour
{

    public float jumpForce = 50;

    private int rail = 0;
    private bool canMove = true;
    private bool canJump = true;
    private bool canSlide = true;
    private Animator animator;
    private Rigidbody rb;

    public UnityAnimationEvent OnAnimationStart;
    public UnityAnimationEvent OnAnimationComplete;
    
    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        for(int i=0; i<animator.runtimeAnimatorController.animationClips.Length; i++)
        {
            AnimationClip clip = animator.runtimeAnimatorController.animationClips[i];
            
            AnimationEvent animationStartEvent = new AnimationEvent();
            animationStartEvent.time = 0;
            animationStartEvent.functionName = "AnimationStartHandler";
            animationStartEvent.stringParameter = clip.name;
            
            AnimationEvent animationEndEvent = new AnimationEvent();
            animationEndEvent.time = clip.length;
            animationEndEvent.functionName = "AnimationCompleteHandler";
            animationEndEvent.stringParameter = clip.name;
            
            clip.AddEvent(animationStartEvent);
            clip.AddEvent(animationEndEvent);
        }
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
        if (Input.GetKeyDown(KeyCode.UpArrow) && canJump)
        {
            rb.AddForce(new Vector3(0,jumpForce,0));
            animator.SetTrigger("Jump");
            canJump=false;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && canSlide)
        {
            animator.SetTrigger("Slide");
            canSlide=false;
        }
    }
    
    IEnumerator MoveDelay()
    {
        canMove = false;
        yield return new WaitForSeconds(0.5f);
        canMove = true;
    }
 

    private void OnCollisionEnter(Collision other) {
        canJump=true;
    }

    public void AnimationStartHandler(string name)
    {
        Debug.Log($"{name} animation start.");
        OnAnimationStart?.Invoke(name);
    }
    public void AnimationCompleteHandler(string name)
    {
        Debug.Log($"{name} animation complete.");
        OnAnimationComplete?.Invoke(name);

        if (name == "Slide")
        {
            canSlide=true;
        }
    }

}
