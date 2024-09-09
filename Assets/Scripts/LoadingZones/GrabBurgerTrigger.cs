using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GrabBurgerTrigger : MonoBehaviour
{
    [SerializeField]
    private Transform _exit;
    [SerializeField]
    private BurgerSlot _table;
    [SerializeField]
    private ClientBurgerQueue _burgerQueue;
    private void OnTriggerEnter(Collider other)
    {
        var agent = other.GetComponentInParent<NavMeshAgent>();
        if (agent != null)
        {
            agent.SetDestination(_exit.position);
            var burgerSlot = other.GetComponentInParent<BurgerSlot>();
            {
                burgerSlot.AddBurger();
            }
            _table.RemoveBurger();
            _burgerQueue.RemoveFirstClient();
            _burgerQueue.MoveQueueOneStep();
        }
    }
}
