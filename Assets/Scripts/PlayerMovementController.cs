using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private FloatingJoystick _floatingJoystick;
    [SerializeField]
    private CharacterController _controller;
    [SerializeField]
    private Animator _animator;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * _floatingJoystick.Vertical + Vector3.right * _floatingJoystick.Horizontal;
        if (direction == Vector3.zero)
        {
            _animator.SetBool("IsWalking", false);
        }
        if (direction != Vector3.zero)
        {
            _animator.SetBool("IsWalking", true);
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y, 0);
            _controller.Move(transform.forward * speed * Time.fixedDeltaTime);
        }
    }
}
