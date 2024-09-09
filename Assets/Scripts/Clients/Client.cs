using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Client : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField]
    private Animator _animator;
    private Quaternion _lookRotation = Quaternion.LookRotation(new Vector3(0, 0, -1));

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (_agent.velocity.magnitude < 0.15f)
        {
            _animator.SetBool("IsWalking", false);
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 2);
        }
        else
        {
            _animator.SetBool("IsWalking", true);
        }
    }


}
