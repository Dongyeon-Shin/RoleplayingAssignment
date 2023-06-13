using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class _2023_06_12 : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float jumpPower;

    private CharacterController controller;
    private Vector3 moveDir;
    private float ySpeed = 0;
    private Animator animator;
    private bool walk;
    private float moveSpeed;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Fall();
    }

    private void Move()
    {
        if (moveDir.magnitude == 0)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, 0.1f);
            animator.SetFloat("MoveSpeed", moveSpeed);
            return;
        }
        Vector3 forwardVector = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z).normalized;
        Vector3 rightVector = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z).normalized;
        if (walk)
        {
            moveSpeed = Mathf.Lerp(moveSpeed, walkSpeed, 0.1f);
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, runSpeed, 0.1f);
        }
        controller.Move(forwardVector * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(rightVector * moveDir.x * moveSpeed * Time.deltaTime);
        animator.SetFloat("MoveSpeed", moveSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(forwardVector * moveDir.z + rightVector * moveDir.x), 0.1f);
        
    }

    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x;
        moveDir.z = value.Get<Vector2>().y;
    }

    private void Fall()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (controller.isGrounded && ySpeed < 0) // isGround는 직접 따로 구현할것
        {
            ySpeed = 0;
        }
        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }

    private void Jump()
    {
        ySpeed = jumpPower;
    }

    private void OnJump(InputValue value)
    {
        Jump();
    }

    private void OnRun(InputValue value)
    {
        walk = !value.isPressed;
    }
}
