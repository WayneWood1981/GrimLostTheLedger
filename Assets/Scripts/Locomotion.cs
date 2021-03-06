using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField] AudioClip thump;

    [SerializeField] ParticleSystem poof;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float fallSpeed;

    [SerializeField]
    private float floatSpeed;

    [SerializeField]
    private CapsuleCollider capCollider;

    [SerializeField]
    private Rigidbody rb;

    private Animator animator;

    public bool isFlyingAway;

    //private CharacterController cc;

    public bool isGrounded;

    private bool isFalling = true;

    public bool hitGround = false;

    public bool isWalking = false;

    public bool isGoingToHeaven = false;

    public bool isGoingToHell = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            Move();
        }

        FlyingToHeaven();
        
    }


    private void FlyingToHeaven()
    {
        if (isGoingToHeaven)
        {
            speed = 0;
            rb.useGravity = false;
            capCollider.enabled = false;
            animator.SetBool("isGoingToHeaven", true);
            transform.Translate(Vector3.up * floatSpeed * Time.deltaTime);
        }
        if (isGoingToHell)
        {
            speed = 0;
            rb.useGravity = false;
            capCollider.enabled = false;
            animator.SetBool("isGoingToHell", true);
            transform.Translate(-Vector3.up * floatSpeed / 2 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Start" || other.transform.tag == "Grass")
        {
            
            
            fallSpeed = 0.1f;
            isGrounded = true;
            hitGround = true;
            animator.SetTrigger("hitGround");
            audioSource.PlayOneShot(thump);
            poof.Play();
            Invoke("Walk", 0.5f);
        }
    }



    private void Walk()
    {
       
        
        if (this.tag != "DeadGuyBeginning")
        {
            isWalking = true;
        }
        else
        {
            animator.SetBool("isGoingToHell", true);
        }
    }

    private void Move()
    {
        if(!isGoingToHeaven && !isGoingToHell)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }
    
}
