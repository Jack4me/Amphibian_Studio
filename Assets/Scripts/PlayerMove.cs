using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
    [SerializeField] private float jumpForce = 10.0f; // Сила прыжка
    public float groundCheckDistance = 0.1f; // Расстояние для определения земли
    public LayerMask groundLayer;

    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    private bool _isGrounded = true;
    private Rigidbody _rigidbody;
    private bool _isWalking;
    private Vector3 moveDir;

    private void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update(){
        HandleMovement();
        // Vector2 inputVectorNormalize = _playerInput.InputVectorNormalize();
        // moveDir = new Vector3(inputVectorNormalize.x, 0, inputVectorNormalize.y);
        // float rotateSpeed = 12;
        // IsWalking = moveDir != Vector3.zero;
        // bool IsOstacle = Physics.Raycast(transform.position, Vector3.forward, 0.4f);
        // Debug.DrawRay(transform.position, moveDir, Color.green, 0.4f);
        // Debug.Log(IsOstacle);
        // float distance = _speed * Time.deltaTime;
        // float playerHeight = 1f;
        // float playerRadius = .7f;
        // bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
        //     playerRadius, moveDir, distance);
        // if (canMove){
        //     if (IsWalking){
        //         transform.position += moveDir * Time.deltaTime * _speed;
        //         transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        //         _animator.SetBool("IsRun", true);
        //     }
        // }
        // else{
        //     IsWalking = false;
        //     _animator.SetBool("IsRun", false);
        // }
        RaycastHit hit;
        bool _isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 0.1f);
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded){
            Jump();
        }
    }

    private void Jump(){
        _rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        _isGrounded = false;
    }
    
    private void HandleMovement(){
        Vector3 inputVector = _playerInput.InputVectorNormalize();
        Vector3 direction = new Vector3(inputVector.x, 0, inputVector.y);
        float distance = _speed * Time.deltaTime;
        float playerHeight = 0.2f;
        float playerRadius = 0.2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight,
            playerRadius, direction, distance);
        Debug.Log(canMove);
        if (!canMove){
            Vector3 moveX = new Vector3(direction.x, 0, 0).normalized;
            canMove = direction.x != 0 && !Physics.CapsuleCast(transform.position,
                transform.position + Vector3.up * playerHeight,
                playerRadius, moveX, distance);
            if (canMove){
                direction = moveX;
            }
            else{
                Vector3 moveZ = new Vector3(0, 0, direction.z).normalized;
                canMove = direction.z != 0 && !Physics.CapsuleCast(transform.position,
                    transform.position + Vector3.up * playerHeight,
                    playerRadius, moveZ, distance);
                if (canMove){
                    direction = moveZ;
                }
            }
        }
        if (canMove){
            transform.position += direction * distance;
        }
        _isWalking = direction != Vector3.zero;
        float rotateSpeed = 12;
        transform.forward = Vector3.Slerp(transform.forward, direction, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking(){
        return _isWalking;
    }
}