using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locomotion : MonoBehaviour
{

    [SerializeField]
    private float speed;

    private Animator animator;

    public bool isFlyingAway;

    private CharacterController cc;

    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animator.SetBool("Walk", true);

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        AddGravity();

        isGrounded = cc.isGrounded;
        
        
    }


    private void AddGravity()
    {
        if (!isFlyingAway)
        {
            cc.Move(-Vector3.up * Time.deltaTime);
        }
        else
        {
            cc.Move(Vector3.up * Time.deltaTime);
        }
        
    }

    private void Move()
    {

        cc.Move(transform.forward * speed * Time.deltaTime);
    }
}
