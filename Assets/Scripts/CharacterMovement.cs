﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{        
    
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public GameObject[] meshes;
    
    private Vector3 _velocity;
    private bool _isGrounded;
    private float _increaseSpeed = 7f;

    private CharacterController _controller;
    private Animator _animator;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position,groundDistance, groundMask);
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = +_increaseSpeed;
        }

        var move = (transform.right * x + transform.forward * z);
        _controller.Move(move * (speed) * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Invoke(nameof(Jump),0.3f);
            _animator.SetTrigger("jump");
        }
        _velocity.y += gravity * Time.deltaTime;
        _animator.SetFloat("speed",Math.Abs(z+x));
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Vodka")){
            StartCoroutine(Flickering());
            GameEvents.current.InvulerAb();
        }
        if(other.CompareTag("Brick") && Enemy.damageAble){
            Destroy(gameObject);
        }
    }    
    private void Jump()
    {
        _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    }
    private IEnumerator Flickering()
    {
        for (int i = 0; i < 3; i++)
        {
            meshes[0].SetActive(false);
            meshes[1].SetActive(false);
            yield return new WaitForSeconds(0.2f);
            meshes[0].SetActive(true);
            meshes[1].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
}